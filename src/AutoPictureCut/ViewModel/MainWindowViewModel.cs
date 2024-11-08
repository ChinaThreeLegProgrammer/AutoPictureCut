using AutoPictureCut.Helper;
using AutoPictureCut.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoPictureCut.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Property
        bool isCanExec = true;
        private string _MainPicture;
        public string MainPicture
        {
            get => _MainPicture;
            set
            {
                _MainPicture = value;
                OnPropertyChanged(nameof(MainPicture));
            }
        }
        private string _BgPicture;
        public string BgPicture
        {
            get => _BgPicture;
            set
            {
                _BgPicture = value;
                OnPropertyChanged(nameof(BgPicture));
            }
        }

        private ObservableCollection<CombineImage> _CombineImageList;
        public ObservableCollection<CombineImage> CombineImageList
        {
            get => _CombineImageList;
            set
            {
                _CombineImageList = value;
                OnPropertyChanged(nameof(CombineImageList));
            }
        }

        #endregion

        #region Command
        public ICommand GetPictureCommand { get; set; }
        /// <summary>
        /// 合成图片
        /// </summary>
        public ICommand CombineImageCommand { get; set; }

        public ICommand OpenDirCommand { get; set; }
        #endregion
        public MainWindowViewModel()
        {
            GetPictureCommand = new DelegateCommand(GetPictureCommandAction, CommandCanExec);
            CombineImageCommand = new DelegateCommand(CombineImageCommandExecute, CommandCanExec);
            OpenDirCommand = new DelegateCommand(OpenDirCommandExecute, CommandCanExec);
        }

        #region Method
        private void OpenDirCommandExecute(object obj)
        {
            if (CombineImageList?.Any() == true)
            {
                string path = CombineImageList.FirstOrDefault().PicturePath;
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = path.Substring(0, path.LastIndexOf("\\")),
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
        }

        private void CombineImageCommandExecute(object obj)
        {
            if (CombineImageList == null)
            {
                CombineImageList = new ObservableCollection<CombineImage>();
            }
            else
                CombineImageList.Clear();
            for (int i = 1; i < 10; i++)
            {
                CombineImageList.Add(new CombineImage()
                {
                    PicturePath = ImgHelper.CombineImage(MainPicture, BgPicture, i),
                    Num = i
                });
            }

        }

        private bool CommandCanExec(object arg)
        {
            return true;
        }

        private void GetPictureCommandAction(object obj)
        {
            Boolean.TryParse(obj?.ToString(), out bool isBackgroundImage);
            string path = WindowsHelper.ShowDialog();
            if (!string.IsNullOrEmpty(path))
            {
                if (isBackgroundImage)
                    BgPicture = path;
                else
                    MainPicture = path;

            }
        }

        #endregion
    }
}
