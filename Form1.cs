using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;





namespace rfid_firebase6
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "Lmju6WwWLRXxmipeDYt4DBFQGnlhdxxHiTc2oEdh",
            BasePath = "https://rfiddata-b6835-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (ClientRectangle != null)
                    MessageBox.Show("Connection 성공!");

                await UpdateDataGridView();
                //폼이 로드될 때 데이터그리드뷰를 업데이트
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예외가 발생했습니다:{ex.Message}");
            }
        }
        private async Task UpdateDataGridView()
        {
            dataGridView1.Columns.Clear(); // 기존에 추가된 열들을 모두 제거
         

            var response = await client.GetAsync("tag");
            if (response.Body != "null")
            {
                var data = response.ResultAs<JObject>();

                var convertedData = data.Properties().Select(entry =>
                {
                    var tagId = entry.Name;
                    var tagData = entry.Value as JObject;

                    var name = tagData.ContainsKey("Name") ? tagData["Name"].ToString() : "";
                    var age = tagData.ContainsKey("Age") ? tagData["Age"].ToString() : "";
                    var gender = tagData.ContainsKey("Gender") ? tagData["Gender"].ToString() : "";

                    return new
                    {
                        태그ID = tagId,
                        이름 = name,
                        나이 = age,
                        성별 = gender
                    };
                });

                dataGridView1.DataSource = new BindingSource(convertedData.ToList(), null);
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

    
  
        private async void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int age = int.Parse(textBox2.Text);
            string gender = radioButton1.Checked ? "남" : "여";
            string tagId = textBox3.Text;

            await SaveTagInfo(tagId, name, age, gender);
            //폼이 로드될 때 데이터그리드뷰를 업데이트
            await UpdateDataGridView();


        }

        private async Task SaveTagInfo(string tagId, string name, int age, string gender)
        {
            var data = new
            {
                Name = name,
                Age = age,
                Gender = gender
            };

            var response = await client.UpdateAsync("tag/" + tagId, data);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("태그 정보를 저장했습니다.");
            }
            else
            {
                MessageBox.Show("태그 정보 저장에 실패했습니다.");
            }
            await UpdateDataGridView();
        }
        // 삭제
       

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();//닫기
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await UpdateDataGridView();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 선택한 행의 인덱스 가져오기
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // 선택한 행의 태그ID 가져오기
                string tagId = dataGridView1.Rows[rowIndex].Cells["태그ID"].Value.ToString();

                // 데이터 삭제
                await DeleteTagInfo(tagId);

                // 데이터 그리드 뷰 업데이트
                await UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("삭제할 행을 선택해주세요.");
            }
        }
        private async Task DeleteTagInfo(string tagId)
        {
            var response = await client.DeleteAsync("tag/" + tagId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("태그 정보를 삭제했습니다.");
            }
            else
            {
                MessageBox.Show("태그 정보 삭제에 실패했습니다.");
            }
        }
    }
}
