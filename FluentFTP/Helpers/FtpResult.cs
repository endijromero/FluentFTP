﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFTP {

	/// <summary>
	/// Stores the result of a file transfer when UploadDirectory or DownloadDirectory is used.
	/// </summary>
	public class FtpResult {

		/// <summary>
		/// Gets the type of file system object.
		/// </summary>
		public FtpFileSystemObjectType Type;

		/// <summary>
		/// Gets the size of the file.
		/// </summary>
		public long Size;

		/// <summary>
		/// Gets the name and extension of the file.
		/// </summary>
		public string Name;

		/// <summary>
		/// Stores the absolute remote path of the the current file being transfered.
		/// </summary>
		public string RemotePath { get; set; }

		/// <summary>
		/// Stores the absolute local path of the the current file being transfered.
		/// </summary>
		public string LocalPath { get; set; }

		/// <summary>
		/// Gets the error that occuring during transfering this file, if any.
		/// </summary>
		public Exception Exception;

		/// <summary>
		/// Returns true if the file was downloaded/uploaded, or the file was already existing with the same file size.
		/// </summary>
		public bool IsSuccess;

		/// <summary>
		/// Was the file skipped?
		/// </summary>
		public bool IsSkipped;

		/// <summary>
		/// Was the file skipped due to failing the rule condition?
		/// </summary>
		public bool IsSkippedByRule;

		/// <summary>
		/// Was there an error during transfer? You can read the Exception property for more details.
		/// </summary>
		public bool IsFailed;

		/// <summary>
		/// Convert this result to a FTP list item.
		/// </summary>
		public FtpListItem ToListItem(bool useLocalPath) {
			return new FtpListItem {
				Type = Type,
				Size = Size,
				Name = Name,
				FullName = useLocalPath ? LocalPath : RemotePath,
			};
		}

	}
}
