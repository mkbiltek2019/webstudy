﻿// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing.Core;
using Leadtools.Controls;

namespace GrayScaleDemo
{
   public partial class PerspectiveDialog : Form
   {
      private ImageViewer _viewer;
      private ViewerForm _form;
      private MainForm _mainForm;
      private List<Point> _polyPoints;
      private Point _lastPoint;
      private Point _currentMousePoint;
      private bool _firstPointSelected;
      private bool _drawing;
      private int _movingPntIdx;
      private RasterImage _orgImage;

      public PerspectiveDialog(MainForm form, ViewerForm viewer)
      {
         _mainForm = form;
         _form = viewer;
         _viewer = viewer.Viewer;
         InitializeComponent();
         _form.DisableInteractiveModes(_form.Viewer);
         _form.Viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id);
      }

      private void PerspectiveDialog_Load(object sender, EventArgs e)
      {
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);
         _form.FormClosing += new FormClosingEventHandler(_form_FormClosing);
         _polyPoints = new List<Point>();
         _firstPointSelected = false;
         _drawing = true;
         _movingPntIdx = -1;
         _orgImage = _viewer.Image.Clone();
         _btnApply.Enabled = false;
         _btnReset.Enabled = false;

         _numSecondPtX.Maximum = _numThirdPtX.Maximum = _numFourthPtX.Maximum = _numFirstPtX.Maximum = _viewer.Image.Width - 1;
         _numFirstPtY.Maximum = _numFourthPtY.Maximum = _numSecondPtY.Maximum = _numThirdPtY.Maximum = _viewer.Image.Height - 1;

         try
         {
            if (_viewer.Floater != null)
            {
               _viewer.Floater.Dispose();
               _viewer.Floater = null;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            _mainForm.UpdateMyControls();
         }
      }


      void _form_FormClosing(object sender, FormClosingEventArgs e)
      {
         this.Close();
      }

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         if (_viewer.ViewBounds.Contains(e.X, e.Y))
         {
            if (e.Button == MouseButtons.Left)
            {
               _movingPntIdx = -1;
            }
         }
      }

      private Rectangle CreateRectFromPoint(Point point, int size)
      {
         return new Rectangle(point.X - size, point.Y - size, size * 2, size * 2);
      }

      void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         if (_viewer.ViewBounds.Contains(e.X, e.Y))
         {
            if (e.Button == MouseButtons.Left)
            {
               double xFactor = _viewer.XScaleFactor;
               double yFactor = _viewer.YScaleFactor;

               int xOffset = _viewer.ClientRectangle.Left;
               int yOffset = _viewer.ClientRectangle.Top;

               Point pnt = new Point((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5));

               _movingPntIdx = -1;

               if (!_drawing)
               {
                  Rectangle[] hyberAreas = new Rectangle[_polyPoints.Count];
                  for (int idx = 0; idx < hyberAreas.Length; idx++)
                  {
                     hyberAreas[idx] = CreateRectFromPoint(_polyPoints[idx], 5);
                     if (hyberAreas[idx].Contains(pnt))
                     {
                        _movingPntIdx = idx;
                        break;
                     }
                  }
               }

               if (_movingPntIdx == -1)
               {
                  if (_polyPoints.Count < 4)
                  {
                     if (pnt.Equals(_lastPoint))
                        return;
                     _firstPointSelected = true;
                     _polyPoints.Add(pnt);
                     _currentMousePoint = pnt;
                     UpdateDialogPoints(_polyPoints.Count - 1, pnt);
                     _lastPoint = pnt;
                  }

                  if (_polyPoints.Count == 4)
                  {
                     _drawing = false;
                     _viewer.Invalidate();
                     _btnApply.Enabled = true;
                  }
               }

            }
         }
      }

      void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         double xFactor = _viewer.XScaleFactor;
         double yFactor = _viewer.YScaleFactor;

         int xOffset = _viewer.ClientRectangle.Left;
         int yOffset = _viewer.ClientRectangle.Top;

         Point pnt = new Point((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5));
         if (_viewer.ViewBounds.Contains(e.X, e.Y))
         {
            _viewer.Cursor = Cursors.Cross;

            if (_firstPointSelected)
            {
               _currentMousePoint = pnt;
            }

            if (_movingPntIdx != -1)
            {
               _polyPoints.RemoveAt(_movingPntIdx);
               _polyPoints.Insert(_movingPntIdx, pnt);
               UpdateDialogPoints(_movingPntIdx, pnt);
            }
            _viewer.Invalidate();
         }
         _txtCursorX.Text = pnt.X.ToString();
         _txtCursorY.Text = pnt.Y.ToString();
      }

      void _viewer_PostRender(object sender, ImageViewerRenderEventArgs args)
      {
         PaintEventArgs e = args.PaintEventArgs;

         if (_firstPointSelected)
         {
            double xFactor = _viewer.XScaleFactor;
            double yFactor = _viewer.YScaleFactor;
            float xOffset = -_viewer.DisplayRectangle.Left;
            float yOffset = -_viewer.DisplayRectangle.Top;

            Point[] drawPoints = new Point[_polyPoints.Count];

            for (int idx = 0; idx < drawPoints.Length; idx++)
            {
               drawPoints[idx] = new Point((int)((_polyPoints[idx].X + xOffset) * xFactor + 0.5), (int)((_polyPoints[idx].Y + yOffset) * yFactor + 0.5));
            }

            Point lastPoint = new Point((int)((_lastPoint.X + xOffset) * xFactor + 0.5), (int)((_lastPoint.Y + yOffset) * yFactor + 0.5));
            Point currentMousePoint = new Point((int)((_currentMousePoint.X + xOffset) * xFactor + 0.5), (int)((_currentMousePoint.Y + yOffset) * yFactor + 0.5));

            int size = 3;
            e.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(drawPoints[0], size));
            for (int i = 1; i < drawPoints.Length; i++)
            {
               Point prev = drawPoints[i - 1];
               Point curnt = drawPoints[i];
               e.Graphics.DrawLine(Pens.Yellow, prev, curnt);
               if (!_drawing)
               {
                  e.Graphics.DrawLine(Pens.Yellow, drawPoints[0], drawPoints[drawPoints.Length - 1]);
               }

               e.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(prev, size));
               e.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(curnt, size));
            }

            if (_drawing && drawPoints.Length < 4)
               e.Graphics.DrawLine(Pens.Green, lastPoint, currentMousePoint);
         }
      }

      private void ApplyFilter()
      {
         if (_polyPoints.Count == 4 && _firstPointSelected)
         {
            List<LeadPoint> PolyPoints = new List<LeadPoint>();
            for (int i = 0; i < 4; i++)
            {
               PolyPoints.Add(new LeadPoint(_polyPoints[i].X, _polyPoints[i].Y));
            }
            KeyStoneCommand command = new KeyStoneCommand(PolyPoints.ToArray());
            try
            {
               command.Run(_viewer.Image);
            }
            catch (System.Exception ex)
            {
               Messager.ShowError(this, ex);
               return;
            }

            _viewer.Cursor = Cursors.Default;
#if !LEADTOOLS_V20_OR_LATER
            _viewer.Image = command.TransformedBitmap.Clone();
#else
            _viewer.Image = command.TransformedImage.Clone();
#endif // #if !LEADTOOLS_V20_OR_LATER
            _viewer.Invalidate();
            _firstPointSelected = false;
            _btnReset.Enabled = true;
            _btnApply.Enabled = false;

         }
      }

      private void _bntApply_Click(object sender, EventArgs e)
      {
         ApplyFilter();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         ApplyFilter();
         (_mainForm.ActiveMdiChild as ViewerForm).addToImageList();
         this.Close();
      }

      private void PerspectiveDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.PostRender -= new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);
         _viewer.Cursor = Cursors.Default;
         _viewer.Invalidate();

         _mainForm.IsSegmentation = false;
         _mainForm.UpdateMyControls();
         (_mainForm.ActiveMdiChild as ViewerForm).UpdateAfterCommandExecution();
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         if (!_firstPointSelected && _polyPoints.Count == 4)
         {
            _firstPointSelected = true;
            _viewer.Image = _orgImage.Clone();
            _btnApply.Enabled = true;
            _btnReset.Enabled = false;
         }

      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _viewer.Image = _orgImage.Clone();
         this.Close();
      }

      private void UpdateDialogPoints(int pointIndex, Point pt)
      {
         switch (pointIndex)
         {
            case 0:
               _numFirstPtX.Value = pt.X;
               _numFirstPtY.Value = pt.Y;
               break;
            case 1:
               _numSecondPtX.Value = pt.X;
               _numSecondPtY.Value = pt.Y;
               break;
            case 2:
               _numThirdPtX.Value = pt.X;
               _numThirdPtY.Value = pt.Y;
               break;
            case 3:
               _numFourthPtX.Value = pt.X;
               _numFourthPtY.Value = pt.Y;
               break;
         }
      }

      private void _numPt_ValueChanged(object sender, EventArgs e)
      {
         if (sender == _numFirstPtX || sender == _numFirstPtY)
         {
            _lastPoint = new Point((int)_numFirstPtX.Value, (int)_numFirstPtY.Value);
            if (_polyPoints.Count >= 1)
            {
               _polyPoints.RemoveAt(0);
               _polyPoints.Insert(0, _lastPoint);
            }
            else
               _polyPoints.Add(_lastPoint);

         }

         if (sender == _numSecondPtX || sender == _numSecondPtY)
         {
            _lastPoint = new Point((int)_numSecondPtX.Value, (int)_numSecondPtY.Value);
            if (_polyPoints.Count >= 2)
            {
               _polyPoints.RemoveAt(1);
               _polyPoints.Insert(1, _lastPoint);
            }
            else
            {
               if (_polyPoints.Count == 0)
                  _polyPoints.Add(new Point(0, 0));
               _polyPoints.Add(_lastPoint);
            }
         }

         if (sender == _numThirdPtX || sender == _numThirdPtY)
         {
            _lastPoint = new Point((int)_numThirdPtX.Value, (int)_numThirdPtY.Value);
            if (_polyPoints.Count >= 3)
            {
               _polyPoints.RemoveAt(2);
               _polyPoints.Insert(2, _lastPoint);
            }
            else
            {
               if (_polyPoints.Count < 2)
               {
                  for (int i = _polyPoints.Count; i < 2; i++)
                     _polyPoints.Add(new Point(0, 0));
               }
               _polyPoints.Add(_lastPoint);
            }
         }

         if (sender == _numFourthPtX || sender == _numFourthPtY)
         {
            _lastPoint = new Point((int)_numFourthPtX.Value, (int)_numFourthPtY.Value);
            if (_polyPoints.Count >= 4)
            {
               _polyPoints.RemoveAt(3);
               _polyPoints.Insert(3, _lastPoint);
            }
            else
            {
               if (_polyPoints.Count < 3)
               {
                  for (int i = _polyPoints.Count; i < 3; i++)
                     _polyPoints.Add(new Point(0, 0));
               }
               _polyPoints.Add(_lastPoint);
               _drawing = false;
            }
         }

         _firstPointSelected = true;
         _viewer.Invalidate();
      }
   }
}
