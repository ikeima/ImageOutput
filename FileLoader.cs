using System.Windows.Forms;

namespace ImageOutput
{
    class FileLoader
    {
        public static string fileName;
        public static string Fileload()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image(JPG,PNG)|*.JPG;*.PNG;|All files (ALL)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                return fileName;
            }
            else return null;
        }
    }
}
