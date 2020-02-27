﻿// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Threading;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Dicom;

namespace Leadtools.DicomDemos
{
   [StructLayout(LayoutKind.Sequential)]
   class DemoDicomTags
   {
#if (LTV15_CONFIG)
      public const DicomTagType MediaStorageSOPClassUID = DicomTagType.MediaStorageSOPClassUID;
      public const DicomTagType PixelData = DicomTagType.PixelData;
      public const DicomTagType SOPClassUID = DicomTagType.SOPClassUID;
      public const DicomTagType Undefined = DicomTagType.Undefined;
      public const DicomTagType DataSetTrailingPadding = DicomTagType.DataSetTrailingPadding;
      public const DicomTagType ItemDelimitationItem = DicomTagType.ItemDelimitationItem;
      public const DicomTagType SequenceDelimitationItem = DicomTagType.SequenceDelimitationItem;
      public const DicomTagType TransferSyntaxUID = DicomTagType.TransferSyntaxUID;
      public const DicomTagType QueryRetrieveLevel = DicomTagType.QueryRetrieveLevel;
      public const DicomTagType StudyInstanceUID = DicomTagType.StudyInstanceUID;
      public const DicomTagType SeriesInstanceUID = DicomTagType.SeriesInstanceUID;
      public const DicomTagType PatientID = DicomTagType.PatientID;
      public const DicomTagType PatientName = DicomTagType.PatientName;
      public const DicomTagType StudyID = DicomTagType.StudyID;
      public const DicomTagType AccessionNumber = DicomTagType.AccessionNumber;
      public const DicomTagType StudyDate = DicomTagType.StudyDate;
      public const DicomTagType Modality = DicomTagType.Modality;
      public const DicomTagType ScheduledProcedureStepStartDate = DicomTagType.ScheduledProcedureStepStartDate;
      public const DicomTagType RequestedProcedureID = DicomTagType.RequestedProcedureID;
      public const DicomTagType SOPInstanceUID = DicomTagType.SOPInstanceUID;
      public const DicomTagType ReferringPhysicianName = DicomTagType.ReferringPhysicianName;
      public const DicomTagType StudyDescription = DicomTagType.StudyDescription;
      public const DicomTagType SeriesDate = DicomTagType.SeriesDate;
      public const DicomTagType SeriesNumber = DicomTagType.SeriesNumber;
      public const DicomTagType SeriesDescription = DicomTagType.SeriesDescription;
      public const DicomTagType NumberOfSeriesRelatedInstances = DicomTagType.NumberOfSeriesRelatedInstances;
      public const DicomTagType InstitutionName = DicomTagType.InstitutionName;
      public const DicomTagType PatientBirthDate = DicomTagType.PatientBirthDate;
      public const DicomTagType PatientSex = DicomTagType.PatientSex;
      public const DicomTagType PatientWeight = DicomTagType.PatientWeight;
      public const DicomTagType RequestingPhysician = DicomTagType.RequestingPhysician;
      public const DicomTagType RequestedProcedureDescription = DicomTagType.RequestedProcedureDescription;
      public const DicomTagType AdmissionID = DicomTagType.AdmissionID;
      public const DicomTagType ScheduledStationAETitle = DicomTagType.ScheduledStationAETitle;
      public const DicomTagType ScheduledProcedureStepStartTime = DicomTagType.ScheduledProcedureStepStartTime;
      public const DicomTagType ScheduledPerformingPhysicianName = DicomTagType.ScheduledPerformingPhysicianName;
      public const DicomTagType ScheduledProcedureStepDescription = DicomTagType.ScheduledProcedureStepDescription;
      public const DicomTagType ScheduledProcedureStepID = DicomTagType.ScheduledProcedureStepID;
      public const DicomTagType ScheduledProcedureStepLocation = DicomTagType.ScheduledProcedureStepLocation;
      public const DicomTagType ReasonForTheRequestedProcedure = DicomTagType.ReasonForTheRequestedProcedure;
      public const DicomTagType RequestedProcedurePriority = DicomTagType.RequestedProcedurePriority;
      public const DicomTagType ScheduledProcedureStepSequence = DicomTagType.ScheduledProcedureStepSequence;
      public const DicomTagType Item = DicomTagType.Item;
      public const DicomTagType ScheduledProtocolCodeSequence = DicomTagType.ScheduledActionItemCodeSequence;
      public const DicomTagType RequestAttributesSequence = DicomTagType.RequestAttributesSequence;
      public const DicomTagType NamesOfIntendedRecipientsOfResults = DicomTagType.NamesOfIntendedRecipientsOfResults;
      public const DicomTagType PhysicianOfRecord = DicomTagType.PhysicianOfRecord;
      public const DicomTagType OperatorName = DicomTagType.OperatorsName;
      public const DicomTagType PerformedProcedureStepID = DicomTagType.PerformedProcedureStepID;
      public const DicomTagType SpecificCharacterSet = DicomTagType.SpecificCharacterSet;
      public const DicomTagType InstanceNumber = DicomTagType.InstanceNumber;
      public const DicomTagType FillerOrderNumberProcedure = DicomTagType.FillerOrderNumberProcedureRetired;
      public const DicomTagType MediaStorageSOPInstanceUID = DicomTagType.MediaStorageSOPInstanceUID;
      public const DicomTagType ImplementationClassUID = DicomTagType.ImplementationClassUID;
      public const DicomTagType ImplementationVersionName = DicomTagType.ImplementationVersionName;
      public const DicomTagType PatientBirthTime = DicomTagType.PatientBirthTime;
      public const DicomTagType EthnicGroup = DicomTagType.EthnicGroup;
      public const DicomTagType PatientComments = DicomTagType.PatientComments;
      public const DicomTagType NumberOfPatientRelatedStudies = DicomTagType.NumberOfPatientRelatedStudies;
      public const DicomTagType NumberOfPatientRelatedSeries = DicomTagType.NumberOfPatientRelatedSeries;
      public const DicomTagType NumberOfPatientRelatedInstances = DicomTagType.NumberOfPatientRelatedInstances;
      public const DicomTagType StudyTime = DicomTagType.StudyTime;
      public const DicomTagType NumberOfStudyRelatedSeries = DicomTagType.NumberOfStudyRelatedSeries;
      public const DicomTagType NumberOfStudyRelatedInstances = DicomTagType.NumberOfStudyRelatedInstances;
      public const DicomTagType ReferencedFileID = DicomTagType.ReferencedFileID;
      public const DicomTagType FileMetaInformationVersion = DicomTagType.FileMetaInformationVersion;
      public const DicomTagType ContentDate = DicomTagType.ContentDate;
      public const DicomTagType ContentTime = DicomTagType.ContentTime;
      public const DicomTagType AcquisitionDateTime = DicomTagType.AcquisitionDatetime;
#else
      public const long MediaStorageSOPClassUID = DicomTag.MediaStorageSOPClassUID;
      public const long PixelData = DicomTag.PixelData;
      public const long SOPClassUID = DicomTag.SOPClassUID;
      public const long Undefined = DicomTag.Undefined;
      public const long DataSetTrailingPadding = DicomTag.DataSetTrailingPadding;
      public const long ItemDelimitationItem = DicomTag.ItemDelimitationItem;
      public const long SequenceDelimitationItem = DicomTag.SequenceDelimitationItem;
      public const long TransferSyntaxUID = DicomTag.TransferSyntaxUID;
      public const long QueryRetrieveLevel = DicomTag.QueryRetrieveLevel;
      public const long StudyInstanceUID = DicomTag.StudyInstanceUID;
      public const long SeriesInstanceUID = DicomTag.SeriesInstanceUID;
      public const long PatientID = DicomTag.PatientID;
      public const long PatientName = DicomTag.PatientName;
      public const long StudyID = DicomTag.StudyID;
      public const long AccessionNumber = DicomTag.AccessionNumber;
      public const long StudyDate = DicomTag.StudyDate;
      public const long Modality = DicomTag.Modality;
      public const long ScheduledProcedureStepStartDate = DicomTag.ScheduledProcedureStepStartDate;
      public const long RequestedProcedureID = DicomTag.RequestedProcedureID;
      public const long SOPInstanceUID = DicomTag.SOPInstanceUID;
      public const long ReferringPhysicianName = DicomTag.ReferringPhysicianName;
      public const long StudyDescription = DicomTag.StudyDescription;
      public const long SeriesDate = DicomTag.SeriesDate;
      public const long SeriesNumber = DicomTag.SeriesNumber;
      public const long SeriesDescription = DicomTag.SeriesDescription;
      public const long NumberOfSeriesRelatedInstances = DicomTag.NumberOfSeriesRelatedInstances;
      public const long InstitutionName = DicomTag.InstitutionName;
      public const long PatientBirthDate = DicomTag.PatientBirthDate;
      public const long PatientSex = DicomTag.PatientSex;
      public const long PatientWeight = DicomTag.PatientWeight;
      public const long RequestingPhysician = DicomTag.RequestingPhysician;
      public const long RequestedProcedureDescription = DicomTag.RequestedProcedureDescription;
      public const long AdmissionID = DicomTag.AdmissionID;
      public const long ScheduledStationAETitle = DicomTag.ScheduledStationAETitle;
      public const long ScheduledProcedureStepStartTime = DicomTag.ScheduledProcedureStepStartTime;
      public const long ScheduledPerformingPhysicianName = DicomTag.ScheduledPerformingPhysicianName;
      public const long ScheduledProcedureStepDescription = DicomTag.ScheduledProcedureStepDescription;
      public const long ScheduledProcedureStepID = DicomTag.ScheduledProcedureStepID;
      public const long ScheduledProcedureStepLocation = DicomTag.ScheduledProcedureStepLocation;
      public const long ReasonForTheRequestedProcedure = DicomTag.ReasonForTheRequestedProcedure;
      public const long RequestedProcedurePriority = DicomTag.RequestedProcedurePriority;
      public const long ScheduledProcedureStepSequence = DicomTag.ScheduledProcedureStepSequence;
      public const long Item = DicomTag.Item;
      public const long ScheduledProtocolCodeSequence = DicomTag.ScheduledProtocolCodeSequence;
      public const long RequestAttributesSequence = DicomTag.RequestAttributesSequence;
      public const long NamesOfIntendedRecipientsOfResults = DicomTag.NamesOfIntendedRecipientsOfResults;
      public const long PhysicianOfRecord = DicomTag.PhysicianOfRecord;
      public const long OperatorName = DicomTag.OperatorName;
      public const long PerformedProcedureStepID = DicomTag.PerformedProcedureStepID;
      public const long SpecificCharacterSet = DicomTag.SpecificCharacterSet;
      public const long InstanceNumber = DicomTag.InstanceNumber;
      public const long FillerOrderNumberProcedure = DicomTag.FillerOrderNumberProcedure;
      public const long MediaStorageSOPInstanceUID = DicomTag.MediaStorageSOPInstanceUID;
      public const long ImplementationClassUID = DicomTag.ImplementationClassUID;
      public const long ImplementationVersionName = DicomTag.ImplementationVersionName;
      public const long PatientBirthTime = DicomTag.PatientBirthTime;
      public const long EthnicGroup = DicomTag.EthnicGroup;
      public const long PatientComments = DicomTag.PatientComments;
      public const long NumberOfPatientRelatedStudies = DicomTag.NumberOfPatientRelatedStudies;
      public const long NumberOfPatientRelatedSeries = DicomTag.NumberOfPatientRelatedSeries;
      public const long NumberOfPatientRelatedInstances = DicomTag.NumberOfPatientRelatedInstances;
      public const long StudyTime = DicomTag.StudyTime;
      public const long NumberOfStudyRelatedSeries = DicomTag.NumberOfStudyRelatedSeries;
      public const long NumberOfStudyRelatedInstances = DicomTag.NumberOfStudyRelatedInstances;
      public const long ReferencedFileID = DicomTag.ReferencedFileID;
      public const long FileMetaInformationVersion = DicomTag.FileMetaInformationVersion;
      public const long ContentDate = DicomTag.ContentDate;
      public const long ContentTime = DicomTag.ContentTime;
      public const long AcquisitionDateTime = DicomTag.AcquisitionDateTime;

#endif
   };
}
