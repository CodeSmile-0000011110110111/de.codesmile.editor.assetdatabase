﻿// Copyright (C) 2021-2023 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using Object = UnityEngine.Object;

namespace CodeSmile.Editor
{
	public sealed partial class Asset
	{
		public static class Database
		{
			/// <summary>
			///     Checks if the object is an asset in the AssetDatabase.
			///     Unlike AssetDatabase, will not throw a NullRef if you pass null.
			/// </summary>
			/// <param name="obj"></param>
			/// <returns>Returns false if the object isn't in the database or if the object is null.</returns>
			public static Boolean Contains(Object obj) => obj ? AssetDatabase.Contains(obj) : false;

			/// <summary>
			///     <p>
			///         Formerly known as 'Refresh()', this scans for and imports assets that have been modified externally.
			///         External is defined as 'any file modification operation not done through the AssetDatabase', for
			///         example by using System.IO methods or by running scripts and other external tools.
			///     </p>
			///     <p>
			///         Since Refresh() 'traditionally' gets called way too many times needlessly a more descriptive name
			///         was chosen to reflect what this method does. I even considered naming it 100% accurately as:
			///         ImportExternallyModifiedAndUnloadUnusedAssets()
			///     </p>
			///     <p>
			///         CAUTION: Calling this needlessly may have an adverse effect on editor performance, since it calls
			///         Resources.UnloadUnusedAssets internally and it also discards any unsaved objects not marked as 'dirty'
			///         that are only referenced by scripts, leading to potential loss of unsaved data.
			///         <see cref="https://docs.unity3d.com/Manual/AssetDatabaseRefreshing.html" />
			///     </p>
			/// </summary>
			/// <param name="options"></param>
			[ExcludeFromCodeCoverage] public static void ImportAll(ImportAssetOptions options =
				ImportAssetOptions.Default) => AssetDatabase.Refresh(options);

			/// <summary>
			///     Will stop Unity from automatically importing assets. Must be called in pair with DisallowAutoRefresh.
			///     Multiple calls must be matched with an equal number of calls to DisallowAutoRefresh since internally
			///     this is using a counter that needs to return to 0 before auto refresh is going to be enabled again.
			///     Note: Has no effect if Preferences => Asset Pipeline => Auto Refresh is disabled to begin with.
			///     Same as AssetDatabase.AllowAutoRefresh().
			/// </summary>
			[ExcludeFromCodeCoverage] public static void AllowAutoRefresh() => AssetDatabase.AllowAutoRefresh();

			/// <summary>
			///     <see cref="AllowAutoRefresh" />
			///     Same as AssetDatabase.DisallowAutoRefresh().
			/// </summary>
			[ExcludeFromCodeCoverage] public static void DisallowAutoRefresh() => AssetDatabase.DisallowAutoRefresh();

			/// <summary>
			///     <see cref="Asset.BatchEditing" />
			///     Internal on purpose: use Asset.BatchEditing(Action) instead
			/// </summary>
			[ExcludeFromCodeCoverage] internal static void StartAssetEditing() => AssetDatabase.StartAssetEditing();

			/// <summary>
			///     <see cref="Asset.BatchEditing" />
			///     Internal on purpose: use Asset.BatchEditing(Action) instead
			/// </summary>
			[ExcludeFromCodeCoverage] internal static void StopAssetEditing() => AssetDatabase.StartAssetEditing();

			// SaveAll

			public static class CacheServer
			{
				/*
	RefreshSettings
	CanConnectToCacheServer
	CloseCacheServerConnection
	GetCacheServerAddress
	GetCacheServerEnableDownload
	GetCacheServerEnableUpload
	GetCacheServerNamespacePrefix
	GetCacheServerPort
	GetCurrentCacheServerIp
	IsCacheServerEnabled
	IsConnectedToCacheServer
	ResetCacheServerReconnectTimer
	WriteImportSettingsIfDirty
				 */
			}

			public static class Labels {}
			public static class SubAsset {}
			public static class Meta {}
			public static class Load {}

			public static class VersionControl
			{
				/*
	CanOpenAssetInEditor
	CanOpenForEdit
	IsMetaFileOpenForEdit
	IsOpenForEdit
	MakeEditable
				 */
			}

			// separate class
			public static class Package
			{
				//Import
				//Export
			}

			public static class Importer
			{
				/*
	ClearImporterOverride
	GetAvailableImporters
	GetDefaultImporter
	GetImporterOverride
	GetImporterType
	GetImporterTypes
	SetImporterOverride
				 */
			}

			public static class Bundle
			{
				/*
	GetAllAssetBundleNames
	GetAssetBundleDependencies
	GetAssetPathsFromAssetBundle
	GetAssetPathsFromAssetBundleAndAssetName
	GetImplicitAssetBundleName
	GetImplicitAssetBundleVariantName
	GetUnusedAssetBundleNames
	RemoveAssetBundleName
	RemoveUnusedAssetBundleNames
				 */
			}
		}
	}
}