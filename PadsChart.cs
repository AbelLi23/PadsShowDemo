using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace PadsShowDemo
{
    public partial class PadsChart : Form
    {
        #region ****************** PadsChart Callbacks and Interfaces ******************
        public PadsChart(Boolean reverseValue)
        {
            InitializeComponent();
            _ReverseChart = reverseValue;
            _PadsSheetList = new List<PadsSheet>();

            TimerForChart.Elapsed += new ElapsedEventHandler(TickTransValue);
            TimerForChart.Interval = 100;
            TimerForChart.Enabled = true;
        }
        public void SetUpPadsChart(int shtNum, int chtCol, int shtRow, int shtCol)//Boolean useImag
        {
            _SheetNum = shtNum; _ChartCol = chtCol; _PadsNum = shtRow * shtCol;
            //_ChartRow = (_SheetNum % _ChartCol == 0) ? (_SheetNum / _ChartCol) : (_SheetNum / _ChartCol + 1);
            if (_SheetNum % _ChartCol == 0) _ChartRow = _SheetNum / _ChartCol;
            else _ChartRow = _SheetNum / _ChartCol + 1;
            List<Point> shtPos = new List<Point>();
            PadsSheet tmpSheet = new PadsSheet(shtRow, shtCol);
            int x = 0, y = 0; _SheetSize = tmpSheet.SheetCalcSize;
            //if (shtRow == 1)//如果一组中只有一行,暂未考虑一列
            //{

            //}
            //else
            //{
            for (int h = 0; h < _ChartRow; h++)
            {
                for (int l = 0; l < _ChartCol; l++)
                {
                    x = (l + 1) * _SheetToSheetGap + l * tmpSheet.SheetCalcSize.Width;
                    y = (h + 1) * _SheetToSheetGap + h * tmpSheet.SheetCalcSize.Height;
                    shtPos.Add(new Point(x, y));
                }
            }
            //}
            _PadsSheetList.Clear();
            for (int sn = 0; sn < shtNum; sn++)
            {
                PadsSheet newSheet;
                if (shtCol == 1 || shtRow == 1) newSheet = new PadsSheet(shtRow, shtCol, _ReverseChart);
                else newSheet = new PadsSheet(shtRow, shtCol);
                _PadsSheetList.Add(newSheet);
                newSheet.NewSheetValue = new Boolean[shtRow * shtCol];
                newSheet.Size = newSheet.SheetCalcSize; newSheet.Location = shtPos[sn];
                this.Controls.Add(newSheet);
                newSheet.BaseCanvas.Refresh();
            }
            //TimerForChart.Enabled = true;
        }
        private void PadsChart_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            var ChartCalcWidth = _ChartCol * _SheetSize.Width + (_ChartCol + 1) * _SheetToSheetGap;
            var ChartCalcHeight = _ChartRow * _SheetSize.Height + (_ChartRow + 1) * _SheetToSheetGap;
            this.Size = new Size(ChartCalcWidth, ChartCalcHeight + labelTip.Height);
            var ChartCalcX = (Screen.GetWorkingArea(this).Width - this.Size.Width) / 2;//(Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2;
            var ChartCalcY = (Screen.GetWorkingArea(this).Height - this.Size.Height) / 2;//(Screen.PrimaryScreen.Bounds.Height - this.Size.Height) / 2;
            this.Location = new Point(ChartCalcX, ChartCalcY);
            this.ShowInTaskbar = true;
            //调整几个小控件的位置
            btExit.Location = new Point(ChartCalcWidth - btExit.Width - _SheetToSheetGap, ChartCalcHeight);
            picBlue.Location = new Point(btExit.Location.X - picBlue.Width - _SheetToSheetGap * 3, btExit.Location.Y);
            labelTip.Location = new Point(picBlue.Location.X - labelTip.Width, btExit.Location.Y);
            picRed.Location = new Point(labelTip.Location.X - picRed.Width, btExit.Location.Y);
        }
        public void SetUpPadsValue()
        {
            _AllPadsValue = new Boolean[_SheetNum, _PadsNum];
            if (bTest)
            {
                for (int i = 0; i < _SheetNum; i++)
                {
                    for (int j = 0; j < _PadsNum; j++)
                    {
                        if (j < _PadsNum / 2)
                            _AllPadsValue[i, j] = true;
                        else
                            _AllPadsValue[i, j] = false;
                    }
                }
                bTest = false;
            }
            else
            {
                for (int i = 0; i < _SheetNum; i++)
                {
                    for (int j = 0; j < _PadsNum; j++)
                    {
                        if (j < _PadsNum / 2)
                            _AllPadsValue[i, j] = false;
                        else
                            _AllPadsValue[i, j] = true;
                    }
                }
                bTest = true;
            }
        }
        int hang = 0, lie = 0, serial = 0;
        public void Increase()
        {
            Boolean[,] initValue = new Boolean[_SheetNum, _PadsNum];
            //Boolean diyValue = new Boolean[_SheetNum * _PadsNum];
            for (int i = 0; i < _SheetNum; i++)
            {
                for (int j = 0; j < _PadsNum; j++)
                {
                    initValue[i, j] = false;
                }
            }
            if (serial == 0)
            { _AllPadsValue = initValue; serial++; }
            else
            {
                _AllPadsValue[hang, lie] = true;
                lie++; serial++;
                if (lie == _PadsNum - 1) { lie = 0; hang++; }
                if (hang == _SheetNum - 1 && lie == _PadsNum - 1)
                {
                    hang = 0; lie = 0; serial = 0;
                }
            }
        }
        private void TickTransValue(Object source, ElapsedEventArgs e)
        {
            Increase();//SetUpPadsValue();
            for (int cc = 0; cc < _SheetNum; cc++)
            {
                for (int pc = 0; pc < _PadsNum; pc++)
                {
                    _PadsSheetList[cc].NewSheetValue[pc] = _AllPadsValue[cc, pc];
                }
            }
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion ****************** PadsChart Callbacks and Interfaces ******************
        //*************************************************************************************************
        #region ****************** PadsChart Properties ******************
        private List<PadsSheet> _PadsSheetList;
        private Size _SheetSize;
        private int _ChartRow = 1, _ChartCol = 1, _SheetNum = 1, _SheetToSheetGap = 1;
        private Boolean[,] _AllPadsValue;
        private int _PadsNum;
        public Boolean[,] AllPadsValue { get { return _AllPadsValue; } set { _AllPadsValue = value; } }
        public Boolean _ReverseChart { get; set; }
        System.Timers.Timer TimerForChart = new System.Timers.Timer();
        Boolean bTest = false;
        #endregion ****************** PadsChart Properties ******************
    }
}
