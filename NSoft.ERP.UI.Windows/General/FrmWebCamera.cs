using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmWebCamera : Form
    {

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public Image captureImage = null;
        public FrmWebCamera()
        {
            InitializeComponent();
        }

        public enum WebCamForm
        {
            Layer1 = 1,
        }

        #region Global variable

        private int formtype;


        #endregion

        #region Overloaded Constructor

        public FrmWebCamera(WebCamForm webCamFrom)
        {
            InitializeComponent();

            if (webCamFrom.Equals(WebCamForm.Layer1))
            {
                formtype = 1;
            }


        }

        #endregion

        #region Form Events

        private void FrmWebCamera_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cmbCameras.Items.Add(Device.Name);

            if (cmbCameras.Items.Count>0)
            {
                cmbCameras.SelectedIndex = 0;
            }
          
            videoCaptureDevice = new VideoCaptureDevice();
        }

        #endregion

        #region Private Methods


        #endregion

        #region Button Click Events

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pbFeed.Image == null)
                return;

            pbPreview.Image = pbFeed.Image;
            captureImage = pbPreview.Image;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbCameras.SelectedIndex == -1)
                return;

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbCameras.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            videoCaptureDevice.Start();

        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbFeed.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            captureImage = null;
            this.Close();
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (formtype.Equals(1))
            {
            }
            this.Close();
        }

        #endregion

        private void FrmWebCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }
    }
}
