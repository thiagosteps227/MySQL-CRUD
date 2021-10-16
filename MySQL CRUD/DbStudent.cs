using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD
{
    class DbStudent
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=admin;database=student";
            MySqlConnection connection = new MySqlConnection(sql);
            try
            {
                connection.Open();
            } catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        public static void addStudent(Student std)
        {
            string sql = "INSERT INTO student_table VALUES (NULL, @StudentName, @StudentReg, @StudentClass, @StudentSection, NULL)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            command.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = std.Reg;
            command.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            command.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (MySqlException ex)
            {
                MessageBox.Show("Student not inserted \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

        }

        public static void updateStudent(Student std, string id)
        {
            string sql = "UPDATE student_table SET Name = @StudentName, Reg = @StudentReg, Class = @StudentClass, Section = @StudentSection WHERE ID = @StudentID)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            command.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = std.Reg;
            command.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            command.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not updated \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

        }

        public static void DeleteStudent(string id)
        {
            string sql = "DELETE FROM student_table WHERE ID = @StudentID";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not deleted \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
