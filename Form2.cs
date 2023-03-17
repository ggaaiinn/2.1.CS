using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _2023역설계3조_2021._3조copy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //pir차트 오른쪽
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("draw");
            chart1.ChartAreas["draw"].AxisX.Minimum = 0;
            chart1.ChartAreas["draw"].AxisX.Maximum = 15; //최초의 차트 폭을 200으로
            chart1.ChartAreas["draw"].AxisX.Interval = 1;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].AxisY.Minimum = 0;
            chart1.ChartAreas["draw"].AxisY.Maximum = 100;
            chart1.ChartAreas["draw"].AxisY.Interval = 10;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].BackColor = Color.Ivory;
            chart1.ChartAreas["draw"].CursorX.AutoScroll = true;
            chart1.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            chart1.Series.Clear();
            chart1.Series.Add("PhotCell");
            chart1.Series["photCell"].ChartType = SeriesChartType.Column;
            chart1.Series["photCell"].Color = Color.DarkSalmon;
            chart1.Series["photCell"].BorderWidth = 7;
            if (chart1.Legends.Count > 0)
                chart1.Legends.RemoveAt(0);

             chart1.Series["PhotoCell"].Points.AddXY("21시", "10");
             chart1.Series["PhotoCell"].Points.AddXY("22시", "20");
             chart1.Series["PhotoCell"].Points.AddXY("23시", "30");
             chart1.Series["PhotoCell"].Points.AddXY("24시", "40");
             chart1.Series["PhotoCell"].Points.AddXY("01시", txt5.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("02시", txt6.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("03시", txt7.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("04시", txt8.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("05시", txt9.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("06시", txt10.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("07시", txt11.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("08시", txt12.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("09시", txt13.Text.ToStrig());
             chart1.Series["PhotoCell"].Points.AddXY("10시", txt14.Text.ToStrig());
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            //심박수차트 왼쪽
            chart2.ChartAreas.Clear();
            chart2.ChartAreas.Add("draw");
            chart2.ChartAreas["draw"].AxisX.Minimum = 0;
            chart2.ChartAreas["draw"].AxisX.Maximum = 15; //최초의 차트 폭을 200으로
            chart2.ChartAreas["draw"].AxisX.Interval = 1;
            chart2.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart2.ChartAreas["draw"].AxisY.Minimum = 0;
            chart2.ChartAreas["draw"].AxisY.Maximum = 100;
            chart2.ChartAreas["draw"].AxisY.Interval = 10;
            chart2.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart2.ChartAreas["draw"].BackColor = Color.Ivory;
            chart2.ChartAreas["draw"].CursorX.AutoScroll = true;
            chart2.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart2.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            chart2.Series.Clear();
            chart2.Series.Add("PhotCell");
            chart2.Series["photCell"].ChartType = SeriesChartType.Column;
            chart2.Series["photCell"].Color = Color.DarkSalmon;
            chart2.Series["photCell"].BorderWidth = 7;
            if (chart1.Legends.Count > 0)
                chart1.Legends.RemoveAt(0);

            chart2.Series["PhotoCell"].Points.AddXY("21시", txt1.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("22시", txt2.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("23시", txt3.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("24시", txt4.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("01시", txt5.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("02시", txt6.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("03시", txt7.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("04시", txt8.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("05시", txt9.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("06시", txt10.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("07시", txt11.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("08시", txt12.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("09시", txt13.Text.ToStrig());
            chart2.Series["PhotoCell"].Points.AddXY("10시", txt14.Text.ToStrig());
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
