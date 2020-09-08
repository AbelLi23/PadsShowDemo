using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PadsShowDemo
{
    public partial class PadsSheet : UserControl
    {
        #region ****************** Canvas, [Pen] and Brush, Image ******************
        private Graphics _PadsCanvas;
        private TextureBrush _PadsBrush;
        private Image _PosState, _NegState;
        private SolidBrush _PosColor, _NegColor;
        private Bitmap _Bmp;
        private Boolean _FirstDraw = true;
        #endregion ****************** Canvas, [Pen] and Brush, Image ******************
        //*************************************************************************************************
        #region ****************** PadsSheet Callbacks and Interfaces ******************
        public void SetUpTimer()
        {
            _TimerForUpdate.Interval = 100;
            _TimerForUpdate.Enabled = true;
        }
        public PadsSheet(int shtRow, int shtCol)
        {
            _SheetRow = shtRow; _SheetCol = shtCol;
            _PosState = Image.FromFile(@"D:\AndyLi2020\Documents\repositories\StdProjs\PadsShowDemo\PadsShowDemo\res\bond200px.png");
            _NegState = Image.FromFile(@"D:\AndyLi2020\Documents\repositories\StdProjs\PadsShowDemo\PadsShowDemo\res\unbond200px.png");
            _PosColor = new SolidBrush(Color.Blue);
            _NegColor = new SolidBrush(Color.Red);
            _CurSheetValue = new Boolean[_SheetRow * _SheetCol];
            for (int i = 0; i < _SheetRow * _SheetCol; i++) { _CurSheetValue[i] = false; }
            _NewSheetValue = new Boolean[_SheetRow * _SheetCol];
            //for (int i = 0; i < _SheetRow * _SheetCol; i++) { _NewSheetValue[i] = false; }
            _SheetCalcSize = new Size(_PadtoPadGap * (_SheetCol + 1) + _SinglePadWidth * _SheetCol, _PadtoPadGap * (_SheetRow + 1) + _SinglePadWidth * _SheetRow);
            //BaseCanvas.Size = _SheetCalcSize;
            _Bmp = new Bitmap(_SheetCalcSize.Width, _SheetCalcSize.Height);
            _PadsCanvas = Graphics.FromImage(_Bmp);//this.CreateGraphics();
            InitializeComponent();
            SetUpTimer();
        }
        public PadsSheet(int shtRow, int shtCol, Boolean reverse)
        {
            //为单个DieBox准备,每一行/列即为一个Sheet
            _SheetRow = shtRow; _SheetCol = shtCol; _ReverseValue = reverse;
            _PosState = Image.FromFile(@"D:\AndyLi2020\Documents\repositories\StdProjs\PadsShowDemo\PadsShowDemo\res\bond200px.png");
            _NegState = Image.FromFile(@"D:\AndyLi2020\Documents\repositories\StdProjs\PadsShowDemo\PadsShowDemo\res\unbond200px.png");
            _PosColor = new SolidBrush(Color.Blue);
            _NegColor = new SolidBrush(Color.Red);
            _CurSheetValue = new Boolean[_SheetRow * _SheetCol];
            for (int i = 0; i < _SheetRow * _SheetCol; i++) { _CurSheetValue[i] = false; }
            _NewSheetValue = new Boolean[_SheetRow * _SheetCol];
            //for (int i = 0; i < _SheetRow * _SheetCol; i++) { _NewSheetValue[i] = false; }
            _SheetCalcSize = new Size(_PadtoPadGap * (_SheetCol + 1) + _SinglePadWidth * _SheetCol, _PadtoPadGap * (_SheetRow + 1) + _SinglePadWidth * _SheetRow);
            //BaseCanvas.Size = _SheetCalcSize;
            _Bmp = new Bitmap(_SheetCalcSize.Width, _SheetCalcSize.Height);
            _PadsCanvas = Graphics.FromImage(_Bmp);//this.CreateGraphics();
            InitializeComponent();
            SetUpTimer();
        }
        private void PadsSheet_Load(object sender, EventArgs e)
        {
            //此Load事件应该只会调用一次
            //_PosState = Image.FromFile(@"D:\AndyLi2020\Documents\repositories\StdProjs\PadsShowDemo\PadsShowDemo\res\bond200px.png");
            //_NegState = Image.FromFile(@"D:\AndyLi2020\Documents\repositories\StdProjs\PadsShowDemo\PadsShowDemo\res\unbond200px.png");
            //_PosColor = new SolidBrush(Color.Green);
            //_NegColor = new SolidBrush(Color.Gray);
            //_Bmp = new Bitmap(this.Width, this.Height);
            //_PadsCanvas = Graphics.FromImage(_Bmp);
            //_CurSheetValue = new Boolean[_SheetRow * _SheetCol];
            //for (int i = 0; i < _SheetRow * _SheetCol; i++) { _CurSheetValue[i] = false; }
            //_NewSheetValue = new Boolean[_SheetRow * _SheetCol];
            //for (int i = 0; i < _SheetRow * _SheetCol; i++) { _NewSheetValue[i] = false; }
            DrawPadsSheet();
            //_TimerForUpdate.Enabled = true;
        }
        private void DrawPadsSheet()
        {
            //★★★★Majority★★★★
            var id = 0; _UseImage = false;
            if (_PadsCanvas != null) _PadsCanvas.Clear(this.BackColor);
            if (_UseImage)
            {
                for (int r = 0; r < _SheetRow; r++)
                {
                    for (int c = 0; c < _SheetCol; c++)
                    {
                        var x = (c + 1) * _PadtoPadGap + (c + 1 / 2) * _SinglePadWidth;
                        var y = (r + 1) * _PadtoPadGap + (r + 1 / 2) * _SinglePadHeight;
                        if (_ReverseValue)
                        {
                            if (r % 2 == 0)
                            {
                                id = r * _SheetCol + _SheetCol - c - 1;
                            }
                            else
                            {
                                id = r * _SheetCol + c;
                            }
                        }
                        else
                        {
                            if (r % 2 == 0)
                            {
                                id = r * _SheetCol + c;
                            }
                            else
                            {
                                id = r * _SheetCol + _SheetCol - c - 1;
                            }
                        }
                        //_CurSheetValue[id] = (_NewSheetValue[id] != _CurSheetValue[id]) ? _NewSheetValue[id] : _CurSheetValue[id];
                        //if (_CurSheetValue[id]) _PadsCanvas.DrawImage(_PosState, x, y, _SinglePadWidth, _SinglePadHeight);
                        if (_NewSheetValue[id] != _CurSheetValue[id])
                        {
                            _CurSheetValue[id] = _NewSheetValue[id];
                            if (_CurSheetValue[id]) _PadsCanvas.DrawImage(_PosState, x, y, _SinglePadWidth, _SinglePadHeight);
                            else _PadsCanvas.DrawImage(_NegState, x, y, _SinglePadWidth, _SinglePadHeight);
                        }
                        else
                        {
                            if (_CurSheetValue[id]) _PadsCanvas.DrawImage(_PosState, x, y, _SinglePadWidth, _SinglePadHeight);
                            else _PadsCanvas.DrawImage(_NegState, x, y, _SinglePadWidth, _SinglePadHeight);
                            //if (_FirstDraw)
                            //{
                            //    _FirstDraw = false;
                            //    if (_CurSheetValue[id]) _PadsCanvas.DrawImage(_PosState, x, y, _SinglePadWidth, _SinglePadHeight);
                            //    else _PadsCanvas.DrawImage(_NegState, x, y, _SinglePadWidth, _SinglePadHeight);
                            //}
                        }
                    }
                }
            }
            else
            {
                for (int r = 0; r < _SheetRow; r++)
                {
                    for (int c = 0; c < _SheetCol; c++)
                    {
                        var x = (c + 1) * _PadtoPadGap + (c + 1 / 2) * _SinglePadWidth;
                        var y = (r + 1) * _PadtoPadGap + (r + 1 / 2) * _SinglePadHeight;
                        if (_ReverseValue)
                        {
                            if (r % 2 == 0)
                            {
                                id = r * _SheetCol + _SheetCol - c - 1;
                            }
                            else
                            {
                                id = r * _SheetCol + c;
                            }
                        }
                        else
                        {
                            if (r % 2 == 0)
                            {
                                id = r * _SheetCol + c;
                            }
                            else
                            {
                                id = r * _SheetCol + _SheetCol - c - 1;
                            }
                        }
                        if (_NewSheetValue[id] != _CurSheetValue[id])
                        {
                            _CurSheetValue[id] = _NewSheetValue[id];
                            if (_CurSheetValue[id]) _PadsCanvas.FillRectangle(_PosColor, x, y, _SinglePadWidth, _SinglePadHeight);
                            else _PadsCanvas.FillRectangle(_NegColor, x, y, _SinglePadWidth, _SinglePadHeight);
                        }
                        else
                        {
                            if (_CurSheetValue[id]) _PadsCanvas.FillRectangle(_PosColor, x, y, _SinglePadWidth, _SinglePadHeight);
                            else _PadsCanvas.FillRectangle(_NegColor, x, y, _SinglePadWidth, _SinglePadHeight);
                            //if (_FirstDraw)
                            //{
                            //    _FirstDraw = false;
                            //    if (_CurSheetValue[id]) _PadsCanvas.FillRectangle(_PosColor, x, y, _SinglePadWidth, _SinglePadHeight);
                            //    else _PadsCanvas.FillRectangle(_NegColor, x, y, _SinglePadWidth, _SinglePadHeight);
                            //}
                        }
                    }
                }
            }
            _PadsBrush = new TextureBrush(_Bmp, WrapMode.Tile);
        }
        private void PadsSheet_Paint(object sender, PaintEventArgs e)
        {
            //DrawPadsSheet();
            Graphics gg = e.Graphics;
            if (_PadsBrush != null)
            {
                //int SheetWidth = _PadtoPadGap * (_SheetCol + 1) + _SinglePadWidth * _SheetCol;
                //int SheetHeight = _PadtoPadGap * (_SheetRow + 1) + _SinglePadWidth * _SheetRow;
                //this.Size = new Size(SheetWidth, SheetHeight);
                BaseCanvas.Size = new Size(_SheetCalcSize.Width, _SheetCalcSize.Height);
                gg.FillRectangle(_PadsBrush, 0, 0, BaseCanvas.Width, BaseCanvas.Height);
            }
        }
        private void TickUpdate(object sender, EventArgs e)
        {
            DrawPadsSheet();
            BaseCanvas.Refresh();
        }
        #endregion ****************** PadsSheet Callbacks and Interfaces ******************
        //*************************************************************************************************
        #region ****************** PadsSheet Properties ******************
        private const int _SinglePadWidth = 4;
        private const int _SinglePadHeight = 4;
        private int _PadtoPadGap = 1;
        public int PadtoPadGap { get { return _PadtoPadGap; } set { _PadtoPadGap = value; } }
        private Boolean _UseImage = true;
        public Boolean UseImage { get { return _UseImage; } set { _UseImage = value; } }
        private int _SheetRow = 1, _SheetCol = 1;
        private Boolean[] _CurSheetValue, _NewSheetValue;
        //public Boolean[] CurSheetValue { get { return _CurSheetValue; } set { _CurSheetValue = value; } }
        public Boolean[] NewSheetValue { get { return _NewSheetValue; } set { _NewSheetValue = value; } }
        private Boolean _ReverseValue = false;
        //private System.Timers.Timer _TimerForUpdate;
        private Size _SheetCalcSize;
        public Size SheetCalcSize { get { return _SheetCalcSize; } set { _SheetCalcSize = value; } }
        #endregion ****************** PadsSheet Properties ******************
    }
}