using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GroupMeetingASP.NETCoreWebApp.Models
{
    public class GroupMeeting
    {

        public int GroupMeetingId { get; set; }
        [Required(ErrorMessage = "Enter Project Name!")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Enter Group Lead Name!")]
        public string GroupMeetingLeadName { get; set; }
        [Required(ErrorMessage = "Enter Team Lead Name!")]
        public string TeamLeadName { get; set; }
        [Required(ErrorMessage = "Enter Description!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Group Meeting Date!")]
        public DateTime GroupMeetingDate { get; set; }

        static string strConnectionString = "User Id=LIAdmin;Password=B!gF!shy!;Server=lisqlserver.database.windows.net;Database=ProjectMeeting;";


        public static IEnumerable<GroupMeeting> GetGroupMeetings()
        {
            List<GroupMeeting> groupMeetingsList = new List<GroupMeeting>();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("GetGroupMeetingDetails", con);
                command.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    GroupMeeting groupMeeting = new GroupMeeting();
                    groupMeeting.GroupMeetingId = Convert.ToInt32(dataReader["Id"]);
                    groupMeeting.ProjectName = dataReader["ProjectName"].ToString();
                    groupMeeting.GroupMeetingLeadName = dataReader["GroupMeetingLeadName"].ToString();
                    groupMeeting.TeamLeadName = dataReader["TeamLeadName"].ToString();
                    groupMeeting.Description = dataReader["Description"].ToString();
                    groupMeeting.GroupMeetingDate = Convert.ToDateTime(dataReader["GroupMeetingDate"]);
                    groupMeetingsList.Add(groupMeeting);
                }
            }
            return groupMeetingsList;
        }

        public static GroupMeeting GetGroupMeetingById(int? id)
        {
            GroupMeeting groupMeeting = new GroupMeeting();
            if (id == null)
                return groupMeeting;

            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("GetGroupMeetingByID", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    groupMeeting.GroupMeetingId = Convert.ToInt32(dataReader["Id"]);
                    groupMeeting.ProjectName = dataReader["ProjectName"].ToString();
                    groupMeeting.GroupMeetingLeadName = dataReader["GroupMeetingLeadName"].ToString();
                    groupMeeting.TeamLeadName = dataReader["TeamLeadName"].ToString();
                    groupMeeting.Description = dataReader["Description"].ToString();
                    groupMeeting.GroupMeetingDate = Convert.ToDateTime(dataReader["GroupMeetingDate"]);
                }
            }
            return groupMeeting;
        }


        public static int AddGroupMeeting(GroupMeeting groupMeeting)
        {
            int rowAffected = 0;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertGroupMeeting", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProjectName", groupMeeting.ProjectName);
                command.Parameters.AddWithValue("@GroupMeetingLeadName", groupMeeting.GroupMeetingLeadName);
                command.Parameters.AddWithValue("@TeamLeadName", groupMeeting.TeamLeadName);
                command.Parameters.AddWithValue("@Description", groupMeeting.Description);
                command.Parameters.AddWithValue("@GroupMeetingDate", groupMeeting.GroupMeetingDate);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            return rowAffected;
        }


        public static int UpdateGroupMeeting(GroupMeeting groupMeeting)
        {
            int rowAffected = 0;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateGroupMeeting", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", groupMeeting.GroupMeetingId);
                command.Parameters.AddWithValue("@ProjectName", groupMeeting.ProjectName);
                command.Parameters.AddWithValue("@GroupMeetingLeadName", groupMeeting.GroupMeetingLeadName);
                command.Parameters.AddWithValue("@TeamLeadName", groupMeeting.TeamLeadName);
                command.Parameters.AddWithValue("@Description", groupMeeting.Description);
                command.Parameters.AddWithValue("@GroupMeetingDate", groupMeeting.GroupMeetingDate);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            return rowAffected;
        }


        public static int DeleteGroupMeeting(int id)
        {
            int rowAffected = 0;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("DeleteGroupMeeting", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            return rowAffected;
        }
    }

}
