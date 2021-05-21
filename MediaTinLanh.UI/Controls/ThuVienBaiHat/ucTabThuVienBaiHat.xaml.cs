using AutoMapper;
using MaterialDesignThemes.Wpf;
using MediaTinLanh.Control;
using MediaTinLanh.Data;
using MediaTinLanh.Model;
using MediaTinLanh.UI.ViewModels;
using MediaTinLanh.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using dbContext = MediaTinLanh.Data.MediaTinLanhContext;

namespace MediaTinLanh.UI.Controls
{
    /// <summary>
    /// Interaction logic for ucThuVienBaiHat.xaml
    /// </summary>
    public partial class ucTabThuVienBaiHat : UserControl
    {
        private ThanhCaViewModel ThanhCaDataContext { get; set; }

        public ucTabThuVienBaiHat()
        {
            InitializeComponent();
            ThanhCaDataContext = (ThanhCaViewModel)this.Resources["ThanhCaContext"];

            var listLoaiThanhCaModel = Mapper.Map<IEnumerable<LoaiBaiHat>, IEnumerable<LoaiBaiHatModel>>(dbContext.LoaiBaiHats.All().ToList());
            ThanhCaDataContext.LoaiBaiHats = new ObservableCollection<LoaiBaiHatModel>(listLoaiThanhCaModel);

            ThanhCaDataContext.SelectedLoaiBaiHat = cbxTieuChi.SelectedItem as LoaiBaiHatModel;

            loadDuLieuThanhCa();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            ThanhCaDataContext.Page = 1;

            loadDuLieuThanhCa();
        }

        private void cbxTieuChi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ThanhCaDataContext.SelectedLoaiBaiHat = cbxTieuChi.SelectedItem as LoaiBaiHatModel;
        }

        private void btnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            if(ThanhCaDataContext.Page != 1)
            {
                ThanhCaDataContext.Page -= 1;

                loadDuLieuThanhCa();
            }
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            var totalPage = ThanhCaDataContext.TotalItem / ThanhCaDataContext.PageSize;
            if (ThanhCaDataContext.Page != totalPage)
            {
                ThanhCaDataContext.Page += 1;

                loadDuLieuThanhCa();
            }
        }

        private void btnTaiVe_Click(object sender, RoutedEventArgs e)
        {
            Button btnTaiVe = sender as Button;

            var inputfilepath = "";
            var fileName = "";
            var filePathOnRemote = "";

            var selectedThanhCa = ThanhCaDataContext.SelectedItem;

            if (selectedThanhCa != null)
            {
                switch (btnTaiVe.Name)
                {
                    case "btnTaiPPTX169":
                        fileName = selectedThanhCa.PPTX.Remove(0, selectedThanhCa.PPTX.LastIndexOf("/") + 1).Replace(" ",string.Empty);
                        var fileName169 = fileName.Substring(0, fileName.LastIndexOf("."))
                                        + "-169" + fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));

                        inputfilepath = browseFilePath() + "\\" + fileName169;
                        filePathOnRemote = selectedThanhCa.PPTX.Contains("/data/") ? selectedThanhCa.PPTX.Replace("/data/", "") : selectedThanhCa.PPTX;

                        //Hiện circle waiting
                        grdWaiting.Visibility = Visibility.Visible;
                        Task.Factory.StartNew(() =>
                        {
                            //YourAction();

                            //Nếu file không tồn tại thì cho phép tải xuống.
                            if (!Control_Files.CheckExit(inputfilepath))
                            {
                                Control_FTP.Download_files(inputfilepath, filePathOnRemote);
                            }

                            readFilePPTXAsync(inputfilepath, "169");

                        }).ContinueWith(Task =>
                        {
                            //Ẩn circle waiting
                            grdWaiting.Visibility = Visibility.Hidden;
                            ShowMessage("Success!", "Đã tải xong file");
                        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                        break;
                    case "btnTaiPPTX43":
                        fileName = selectedThanhCa.PPTX.Remove(0, selectedThanhCa.PPTX.LastIndexOf("/") + 1).Replace(" ", string.Empty);
                        var fileName43 = fileName.Substring(0, fileName.LastIndexOf("."))
                                        + "-43" + fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));

                        inputfilepath = browseFilePath() + "\\" + fileName43;
                        filePathOnRemote = selectedThanhCa.PPTX.Contains("/data/") ? selectedThanhCa.PPTX.Replace("/data/", "") : selectedThanhCa.PPTX;

                        //Hiện circle waiting
                        grdWaiting.Visibility = Visibility.Visible;
                        Task.Factory.StartNew(() =>
                        {
                            //YourAction();

                            //Nếu file không tồn tại thì cho phép tải xuống.
                            if (!Control_Files.CheckExit(inputfilepath))
                            {
                                Control_FTP.Download_files(inputfilepath, filePathOnRemote);
                            }

                            readFilePPTXAsync(inputfilepath);

                        }).ContinueWith(Task =>
                        {
                            //Ẩn circle waiting
                            grdWaiting.Visibility = Visibility.Hidden;
                            ShowMessage("Success!", "Đã tải xong file");
                        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                        break;
                    case "btnTaiTXT":
                        fileName = selectedThanhCa.TXT.Remove(0, selectedThanhCa.TXT.LastIndexOf("/") + 1).Replace(" ", string.Empty);

                        inputfilepath = browseFilePath() + "\\" + fileName;
                        filePathOnRemote = selectedThanhCa.TXT.Contains("/data/") ? selectedThanhCa.TXT.Replace("/data/", "") : selectedThanhCa.TXT;

                        //Hiện circle waiting
                        grdWaiting.Visibility = Visibility.Visible;
                        Task.Factory.StartNew(() =>
                        {
                            //YourAction();
                            if (!Control_Files.CheckExit(inputfilepath))
                            {
                                Control_FTP.Download_files(inputfilepath, filePathOnRemote);
                            }

                            Process.Start(inputfilepath);

                        }).ContinueWith(Task =>
                        {
                            //Ẩn circle waiting
                            grdWaiting.Visibility = Visibility.Hidden;
                            ShowMessage("Success!", "Đã tải xong file TXT");
                        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                        break;
                    case "btnTaiPDF":
                        fileName = selectedThanhCa.PDF.Remove(0, selectedThanhCa.PDF.LastIndexOf("/") + 1).Replace(" ", string.Empty);

                        inputfilepath = browseFilePath() + "\\" + fileName;
                        filePathOnRemote = selectedThanhCa.PDF.Contains("/data/") ? selectedThanhCa.PDF.Replace("/data/", "") : selectedThanhCa.PDF;

                        //Hiện circle waiting
                        grdWaiting.Visibility = Visibility.Visible;
                        Task.Factory.StartNew(() =>
                        {
                            //YourAction();

                            //Nếu file không tồn tại thì cho phép tải xuống.
                            if (!Control_Files.CheckExit(inputfilepath))
                            {
                                Control_FTP.Download_files(inputfilepath, filePathOnRemote);
                            }

                            Process.Start(inputfilepath);

                        }).ContinueWith(Task =>
                        {
                            //Ẩn circle waiting
                            grdWaiting.Visibility = Visibility.Hidden;
                            ShowMessage("Success!", "Đã tải xong file PDF");
                        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                        break;
                }
            }
            else
            {
                ShowMessage("Warning!", "Vui lòng chọn bài hát trước khi tải");
            }


        }

        private void readFilePPTXAsync(string filePath = null, string slideSize = "OnScreen")
        {
            //Nếu file tồn tại thì cho phép xem.
            if (Control_Files.CheckExit(filePath))
            {
                var inputfilepath = filePath;

                Microsoft.Office.Interop.PowerPoint.Application pptApp = new Microsoft.Office.Interop.PowerPoint.Application();
                Microsoft.Office.Core.MsoTriState ofalse = Microsoft.Office.Core.MsoTriState.msoFalse;
                Microsoft.Office.Core.MsoTriState otrue = Microsoft.Office.Core.MsoTriState.msoTrue;
                pptApp.Visible = otrue;
                pptApp.Activate();
                Microsoft.Office.Interop.PowerPoint.Presentations ps = pptApp.Presentations;
                Microsoft.Office.Interop.PowerPoint.Presentation p = ps.Open(inputfilepath, ofalse, ofalse, otrue);
                if (slideSize == "OnScreen")
                {
                    p.PageSetup.SlideSize = Microsoft.Office.Interop.PowerPoint.PpSlideSizeType.ppSlideSizeOnScreen;
                }
                else
                {
                    p.PageSetup.SlideSize = Microsoft.Office.Interop.PowerPoint.PpSlideSizeType.ppSlideSizeOnScreen16x9;
                }

                p.Save();
            }
        }

        private void listViewThanhCa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedThanhCa = ThanhCaDataContext.SelectedItem;

                if (selectedThanhCa.LoiBaiHats.Count == 0)
                {
                    var loiBaiHats = dbContext.LoiBaiHats.All(where: "ID_ThanhCa = @0", parms: new object[] { selectedThanhCa.STT });
                    var loiBaiHatModels = Mapper.Map<IEnumerable<LoiBaiHat>, IEnumerable<LoiBaiHatModel>>(loiBaiHats);

                    selectedThanhCa.LoiBaiHats = new ObservableCollection<LoiBaiHatModel>(loiBaiHatModels);
                }

                tblNoiDungBaiHat.TextAlignment = TextAlignment.Left;
                tblNoiDungBaiHat.Text = string.Empty;

                foreach (var loiBaiHat in selectedThanhCa.LoiBaiHats)
                {

                    tblNoiDungBaiHat.Text += loiBaiHat.NoiDung + Environment.NewLine;
                    tblNoiDungBaiHat.Text += Environment.NewLine;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnBaoLoi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loadDuLieuThanhCa()
        {
            var filterTenThanhCa = !string.IsNullOrEmpty(txtTimBaiHat.Text) ? $"AND Ten COLLATE UTF8CI LIKE {"'%" + txtTimBaiHat.Text + "%'"}" : "";

            int toTal = ThanhCaDataContext.TotalItem;
            var listThanhCa = dbContext.ThanhCas.Paged(out toTal,
                where: "Loai = @0 " + filterTenThanhCa,
                orderBy: "STT ASC",
                page: ThanhCaDataContext.Page,
                pageSize: ThanhCaDataContext.PageSize, parms: new object[] { ThanhCaDataContext.SelectedLoaiBaiHat.ID });
            var listThanhCaModel = Mapper.Map<List<ThanhCa>, List<ThanhCaModel>>(listThanhCa.ToList());

            ThanhCaDataContext.Items = new ObservableCollection<ThanhCaModel>(listThanhCaModel);
        }

        private string browseFilePath()
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }

        private async void ShowMessage(string title, string message)
        {
            var sampleMessageDialog = new MessageViewModel
            {
                Message = message,
                Title = title
            };

            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }
        
    }
}
