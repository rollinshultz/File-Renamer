using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileRenamer
{
	class FileHandlerClass
	{
		private String[] _files; //Using array instead of Geric List because it will be used only with strings
		public String directory { get; set; }
		public String TextToRemove{get; set;}
        public String TextToReplace { get; set; }
		public String Prefix{get; set;}
		public String Suffix { get; set; }
		public string OldExtension { get; set; }
		public String NewExtension{get; set;}

		
		
		public void GetDirectory()
		{
			var dlg = new System.Windows.Forms.FolderBrowserDialog();
			System.Windows.Forms.DialogResult result = dlg.ShowDialog();
			if ( result == DialogResult.OK)
			{
				directory = dlg.SelectedPath;
			}
			else
			{
				MessageBox.Show("directory not returned");
			}
		}
			   
		public void GetFiles()
		{
			try
			{

				if (directory != String.Empty && OldExtension != String.Empty)
				{
					_files = Directory.GetFiles(directory, GetExtension(OldExtension));
				}
				
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("Directory and or Extension not selected");
			}
		}

		public String GetExtension(String extension)
		{
			if (extension != String.Empty)
			{
				
				if (!extension.Contains("." ))
				{ 
					return "*." + extension;
				}
				else
				{
					return "*" + extension;
				}
			} return false.ToString();
		}

		public void ChangeFilename()
		{
			GetFiles();
			StringBuilder fileName = new StringBuilder();// using to build new filename string
			foreach (string file in _files)
			{
				int count = 1; //used to start at 1 for sequential numbering 

				fileName.Append(file.Substring(file.LastIndexOf('\\') + 1)); //extracts filename from full pathname
				
				if (this.TextToRemove != String.Empty)//check if there is any text to remove from new filename
				{
					fileName.Replace(TextToRemove, TextToReplace); // removes chosen string from filename
				}

				if (Prefix != String.Empty) //check if there is a prefix
				{
					fileName.Insert(0, (Prefix + " " + count.ToString() + " ")); //insert prefix at beginning of new filename
				}

				if (Suffix != String.Empty)
				{
                    Debug.WriteLine("File name is "+ fileName.ToString());
                    Debug.WriteLine("file length is " + file.Length.ToString());
                    Debug.WriteLine("last index is " + file.IndexOf('.'));
                    fileName.Insert((fileName.Length - 4), Suffix);

				}
				
				if(NewExtension != String.Empty) //check if there is an extension change (not required)
				{

					fileName.Replace(OldExtension, NewExtension);// replace old ext with new one
				}
				// New file assembled, next increment count to get next file
				fileName.Insert(0, directory + "\\");
				count++;
				Debug.WriteLine(fileName);
				File.Move(file, fileName.ToString());
				fileName.Clear();// clears the stringbuilder for new file
			}
		}

		public void ChangeExtension()
		{
			try
			{
				GetFiles();
			}
			catch
			{
				MessageBox.Show("Please select a directory");
				GetDirectory();
			}

			try
			{
				foreach (String file in _files)
				{
					if (_files.Length > 0 && NewExtension != String.Empty)
					{
						File.Move(file, Path.ChangeExtension(file, NewExtension));
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("New extension must be supplied");
			}
		}

	}
}
