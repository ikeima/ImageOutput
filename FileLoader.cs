using System.Windows.Forms;

namespace ImageOutput
{
    class FileLoader
    {
        public static string fileName;
        public static string[] fileNames;
        public static string[] Fileload()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image(JPG,PNG)|*.JPG;*.PNG;|All files (ALL)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;
                return fileNames;
            }
            else return null;
        }
    }
}
