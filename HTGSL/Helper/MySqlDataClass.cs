using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace HTGSL
{
    public class MySqlDataClass
    {
        private SqlConnection SqlConnect;
        public MySqlDataClass()
        {
        }
        public MySqlDataClass(SqlConnection sql_connect)
        {
            this.SqlConnect = sql_connect;
        }
        public bool IsOpen()
        {
            return this.SqlConnect.State == ConnectionState.Open;
        }
        private string GetStringSqlDateRange(bool b_from_date, DateTime dt_from_date, bool b_to_date, DateTime dt_to_date)
        {
            DateTime dateTime = b_from_date ? dt_from_date : new DateTime(2000, 1, 1);
            DateTime dateTime2 = b_to_date ? dt_to_date : new DateTime(20250, 12, 31);
            string text = dateTime.ToString("MM/dd/yyyy") + " 00:00:00";
            string text2 = dateTime2.ToString("MM/dd/yyyy") + " 00:00:00";
            return string.Concat(new string[]
			{
				" Between '",
				text,
				"' And '",
				text2,
				"' "
			});
        }
        public HospitalInfo ReaderHospitalInfo(int i_hospital_id)
        {
            HospitalInfo hospitalInfo = null;
            HospitalInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select  hospital_id, hospital_name,  address, website, email,  phone, fax,  note  From HOSPITAL  Where hospital_id = " + i_hospital_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_hospital_id2 = int.Parse(sqlDataReader[0].ToString());
                    string str_hospital_name = sqlDataReader[1].ToString();
                    string str_address = sqlDataReader[2].ToString();
                    string str_website = (sqlDataReader[3].ToString().Trim() == string.Empty) ? "" : sqlDataReader[3].ToString().Trim();
                    string str_email = (sqlDataReader[4].ToString().Trim() == string.Empty) ? "" : sqlDataReader[4].ToString().Trim();
                    string str_phone = (sqlDataReader[5].ToString().Trim() == string.Empty) ? "" : sqlDataReader[5].ToString().Trim();
                    string str_fax = (sqlDataReader[6].ToString().Trim() == string.Empty) ? "" : sqlDataReader[6].ToString().Trim();
                    string str_note = (sqlDataReader[7].ToString().Trim() == string.Empty) ? "" : sqlDataReader[7].ToString().Trim();
                    hospitalInfo = new HospitalInfo(i_hospital_id2, str_hospital_name, str_address, str_website, str_email, str_phone, str_fax, str_note);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = hospitalInfo;
            return result;
        }
        public bool InsertHospitalInfo(int i_hospital_id, string str_hospital_name, string str_address, string str_website, string str_email, string str_phone, string str_fax, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into HOSPITAL  (  hospital_id,  hospital_name,  address,  website,  email,  phone,  fax,  note  )  Values  (  ",
					i_hospital_id.ToString(),
					",  N'",
					str_hospital_name.Trim(),
					"',  N'",
					str_address.Trim(),
					"',  ",
					(str_website.Trim() == string.Empty) ? "null" : ("'" + str_website.Trim() + "'"),
					",  ",
					(str_email.Trim() == string.Empty) ? "null" : ("'" + str_email.Trim() + "'"),
					",  ",
					(str_phone.Trim() == string.Empty) ? "null" : ("'" + str_phone.Trim() + "'"),
					",  ",
					(str_fax.Trim() == string.Empty) ? "null" : ("'" + str_fax.Trim() + "'"),
					",  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					"  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateHospitalInfo(int i_hospital_id, string str_hospital_name, string str_address, string str_website, string str_email, string str_phone, string str_fax, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update HOSPITAL  Set  hospital_name = N'",
					str_hospital_name.Trim(),
					"',  address = N'",
					str_address.Trim(),
					"',  website = ",
					(str_website.Trim() == string.Empty) ? "null" : ("N'" + str_website.Trim() + "'"),
					",  email = ",
					(str_email.Trim() == string.Empty) ? "null" : ("'" + str_email.Trim() + "'"),
					",  phone = ",
					(str_phone.Trim() == string.Empty) ? "null" : ("'" + str_phone.Trim() + "'"),
					",  fax = ",
					(str_fax.Trim() == string.Empty) ? "null" : ("'" + str_fax.Trim() + "'"),
					",  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("'" + str_note.Trim() + "'"),
					"  Where hospital_id = ",
					i_hospital_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public HospitalNodeInfo ReaderHospitalNode(int i_hospital_id)
        {
            HospitalNodeInfo hospitalNodeInfo = null;
            HospitalNodeInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select hospital_id, hospital_name  From HOSPITAL  Where hospital_id = " + i_hospital_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_hospital_id2 = int.Parse(sqlDataReader[0].ToString());
                    string str_hospital_name = sqlDataReader[1].ToString();
                    hospitalNodeInfo = new HospitalNodeInfo(i_hospital_id2, str_hospital_name, new RegionNodeArray());
                }
                sqlDataReader.Close();
                if (hospitalNodeInfo != null)
                {
                    hospitalNodeInfo.Regions = this.ReaderRegionNodes();
                }
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = hospitalNodeInfo;
            return result;
        }
        public string GetServiceName(int i_service_id)
        {
            string text = "No service";
            string result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select service_name  From SERVICES  Where service_id = " + i_service_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    text = sqlDataReader[0].ToString();
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = text;
                return result;
            }
            result = text;
            return result;
        }
        public RegionNodeArray ReaderRegionNodes()
        {
            RegionNodeArray regionNodeArray = new RegionNodeArray();
            RegionNodeArray result;
            try
            {
                string serviceName = this.GetServiceName(0);
                string serviceName2 = this.GetServiceName(1);
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select region_id, region_name  From REGIONS  Order By region_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_region_id = int.Parse(sqlDataReader[0].ToString());
                    string str_region_name = sqlDataReader[1].ToString();
                    RoomsNodeInfo rn_rooms = new RoomsNodeInfo(0, serviceName, new RoomNodeArray());
                    LocationsNodeInfo ln_locations = new LocationsNodeInfo(1, serviceName2);
                    regionNodeArray.Add(new RegionNodeInfo(i_region_id, str_region_name, rn_rooms, ln_locations));
                }
                sqlDataReader.Close();
                foreach (RegionNodeInfo regionNodeInfo in regionNodeArray)
                {
                    SqlCommand sqlCommand2 = this.SqlConnect.CreateCommand();
                    sqlCommand2.CommandText = " Select room_id, room_name  From ROOMS  Where region_id = " + regionNodeInfo.iRegionID.ToString() + "  Order By room_id ";
                    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                    while (sqlDataReader2.Read())
                    {
                        int i_room_id = int.Parse(sqlDataReader2[0].ToString());
                        string str_room_name = sqlDataReader2[1].ToString();
                        regionNodeInfo.rnRooms.Rooms.Add(new RoomNodeInfo(i_room_id, str_room_name));
                    }
                    sqlDataReader2.Close();
                }
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new RegionNodeArray();
                return result;
            }
            result = regionNodeArray;
            return result;
        }
        public RegionArray ReaderRegions()
        {
            RegionArray regionArray = new RegionArray();
            RegionArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select M.region_id, M.region_name, M.note,  (  Select Count(*)  From ROOMS  Where region_id = M.region_id  ) As total_of_rooms,  (  Select Count(*)  From LOCATIONS  Where region_id = M.region_id  ) As total_of_locations  From  (  Select region_id, region_name, note  From REGIONS  ) M Order By M.region_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_region_id = int.Parse(sqlDataReader[0].ToString());
                    string str_region_name = sqlDataReader[1].ToString();
                    string str_note = sqlDataReader.IsDBNull(2) ? " " : sqlDataReader[2].ToString();
                    int i_total_of_rooms = int.Parse(sqlDataReader[3].ToString());
                    int i_total_of_locations = int.Parse(sqlDataReader[4].ToString());
                    RegionInfo ri = new RegionInfo(i_region_id, str_region_name, str_note, i_total_of_rooms, i_total_of_locations);
                    regionArray.Add(ri);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new RegionArray();
                return result;
            }
            result = regionArray;
            return result;
        }
        public RegionInfo ReaderRegionInfo(int i_region_id)
        {
            RegionInfo regionInfo = null;
            RegionInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select M.region_id, M.region_name, M.note,  (  Select Count(*)  From ROOMS  Where region_id = M.region_id  ) As total_of_rooms,  (  Select Count(*)  From LOCATIONS  Where region_id = M.region_id  ) As total_of_locations  From  (  Select region_id, region_name, note  From REGIONS  Where region_id = " + i_region_id.ToString() + "  ) M ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_region_id2 = int.Parse(sqlDataReader[0].ToString());
                    string str_region_name = sqlDataReader[1].ToString();
                    string str_note = sqlDataReader.IsDBNull(2) ? "" : sqlDataReader[2].ToString();
                    int i_total_of_rooms = int.Parse(sqlDataReader[3].ToString());
                    int i_total_of_locations = int.Parse(sqlDataReader[4].ToString());
                    regionInfo = new RegionInfo(i_region_id2, str_region_name, str_note, i_total_of_rooms, i_total_of_locations);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = regionInfo;
            return result;
        }
        public bool InsertRegionInfo(int i_region_id, string str_region_name, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into REGIONS  (  region_id,  region_name,  note  )  Values  (  ",
					i_region_id.ToString(),
					",  N'",
					str_region_name.Trim(),
					"',  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note + "'"),
					"  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateRegionInfo(int i_region_id, string str_region_name, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update REGIONS  Set  region_name = N'",
					str_region_name.Trim(),
					"',  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					"  Where region_id = ",
					i_region_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool DeleteRegionInfo(int i_region_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Delete From REGIONS  Where region_id = " + i_region_id.ToString();
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool IsExistRegionID(int i_region_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From REGIONS  Where region_id = " + i_region_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueRegionID()
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(region_id) As MaxValue From REGIONS ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public RoomArray ReaderRoomsOfRegion(int i_region_id)
        {
            RoomArray roomArray = new RoomArray();
            RoomArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select M.room_id, M.region_id, M.room_name, M.region_name, M.note,  (  Select Count(*)  From BEDS  Where  region_id = M.region_id And  room_id = M.room_id  ) As total_of_beds, M.labors  From  (  Select A.room_id, A.region_id, A.room_name, B.region_name, A.note, A.labors  From ROOMS A, REGIONS B  Where  A.region_id = B.region_id And  A.region_id = " + i_region_id.ToString() + " ) M Order By M.room_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_room_id = int.Parse(sqlDataReader[0].ToString());
                    int i_region_id2 = int.Parse(sqlDataReader[1].ToString());
                    string str_room_name = sqlDataReader[2].ToString();
                    string str_region_name = sqlDataReader[3].ToString();
                    string str_note = sqlDataReader.IsDBNull(4) ? " " : sqlDataReader[4].ToString();
                    int i_total_of_beds = int.Parse(sqlDataReader[5].ToString());
                    int i_labors = int.Parse(sqlDataReader[6].ToString());
                    RoomInfo ri = new RoomInfo(i_room_id, i_region_id2, str_room_name, str_region_name, str_note, i_total_of_beds,i_labors);
                    roomArray.Add(ri);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new RoomArray();
                return result;
            }
            result = roomArray;
            return result;
        }
        public RoomInfo ReaderRoomInfo(int i_room_id, int i_region_id)
        {
            RoomInfo roomInfo = null;
            RoomInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
                    " Select M.room_id, M.region_id, M.room_name, M.region_name, M.note,  (  Select Count(*)  From BEDS  Where  region_id = M.region_id And  room_id = M.room_id  ) As total_of_beds, M.labors ",
                    " From  (  Select A.room_id, A.region_id, A.room_name, B.region_name, A.note,A.labors  From ROOMS A, REGIONS B ",
                    "  Where  A.region_id = B.region_id And  A.region_id = ",
					i_region_id.ToString(),
					" And  A.room_id = ",
					i_room_id.ToString(),
					" ) M "
				});
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_room_id2 = int.Parse(sqlDataReader[0].ToString());
                    int i_region_id2 = int.Parse(sqlDataReader[1].ToString());
                    string str_room_name = sqlDataReader[2].ToString();
                    string str_region_name = sqlDataReader[3].ToString();
                    string str_note = sqlDataReader.IsDBNull(4) ? " " : sqlDataReader[4].ToString();
                    int i_total_of_beds = int.Parse(sqlDataReader[5].ToString());
                    int i_labors = int.Parse(sqlDataReader[6].ToString());
                    roomInfo = new RoomInfo(i_room_id2, i_region_id2, str_room_name, str_region_name, str_note, i_total_of_beds,i_labors);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = roomInfo;
            return result;
        }
        public bool IsExistRoomID(int i_room_id, int i_region_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From ROOMS  Where  region_id = " + i_region_id.ToString() + " And  room_id = " + i_room_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueRoomID(int i_region_id)
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(room_id) As MaxValue  From ROOMS  Where  region_id = " + i_region_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public bool InsertRoomInfo(int i_room_id, int i_region_id, string str_room_name, string str_note, int i_labors)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into ROOMS  (  room_id,  region_id,  room_name,  note,labors  )  Values  (  ",
					i_room_id.ToString(),
					",  ",
					i_region_id.ToString(),
					",  N'",
					str_room_name.Trim(),
					"',  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note + "'"),
                    ",  ",
                    i_labors.ToString(),
                    "  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateRoomInfo(int i_room_id, int i_region_id, string str_room_name, string str_note, int i_labor)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update ROOMS  Set  room_name = N'",
					str_room_name.Trim(),
					"',  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
                    ",  labors = ",
                    i_labor.ToString(),
                    "  Where  region_id = ",
					i_region_id.ToString(),
					" And  room_id = ",
					i_room_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool DeleteRoomInfo(int i_room_id, int i_region_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Delete From ROOMS  Where  region_id = " + i_region_id.ToString() + " And  room_id = " + i_room_id.ToString();
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool IsExistRoomsInRegion(int i_region_id)
        {
            int num = 0;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From ROOMS  Where  region_id = " + i_region_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public BedArray ReaderBedsOfRoom(int i_room_id, int i_region_id)
        {
            BedArray Bs = new BedArray();
            try
            {
                SqlCommand cmd = this.SqlConnect.CreateCommand();
                cmd.CommandText =
                    " Select A.bed_id, A.room_id, A.region_id, A.bed_name, B.room_name, C.region_name, A.note, A.install , E.employee_id, E.first_name + ' ' + E.last_name AS name" +
                    " From BEDS A, ROOMS B, REGIONS C , EMPLOYEES E" +
                    " Where " +
                    " A.room_id = B.room_id And " +
                    " A.region_id = C.region_id And " +
                    " B.region_id = C.region_id And " +
                    " E.employee_id = A.curator And " +
                    " A.region_id = " + i_region_id.ToString() + " And " +
                    " A.room_id = " + i_room_id.ToString() +
                    " Order By A.bed_id ";
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int iBedID = Int32.Parse(myReader[0].ToString());
                    int iRoomID = Int32.Parse(myReader[1].ToString());
                    int iRegionID = Int32.Parse(myReader[2].ToString());
                    string strBedName = myReader[3].ToString();
                    string strRoomName = myReader[4].ToString();
                    string strRegionName = myReader[5].ToString();
                    string strNote = myReader.IsDBNull(6) ? " " : myReader[6].ToString();
                    bool bInstall = bool.Parse(myReader[7].ToString());
                    int icurator = int.Parse(myReader[8].ToString());
                    string curator = myReader[9].ToString();
                    BedInfo Bi = new BedInfo(iBedID, iRoomID, iRegionID, strBedName, strRoomName, strRegionName, strNote, bInstall, icurator, curator);
                    Bs.Add(Bi);
                }
                myReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                return new BedArray();
            }
            return Bs;
        }

        public BedInfo ReaderBedInfo(int i_bed_id, int i_room_id, int i_region_id)
        {
            BedInfo Bi = null;
            try
            {
                SqlCommand cmd = this.SqlConnect.CreateCommand();
                cmd.CommandText =
                    " Select A.bed_id, A.room_id, A.region_id, A.bed_name, B.room_name, C.region_name, A.note, A.install, E.employee_id, E.first_name + ' ' + E.last_name AS name " +
                    " From BEDS A, ROOMS B, REGIONS C, EMPLOYEES E" +
                    " Where " +
                    " A.room_id = B.room_id And " +
                    " A.region_id = C.region_id And " +
                    " B.region_id = C.region_id And " +
                    " E.employee_id = A.curator And " +
                    " A.region_id = " + i_region_id.ToString() + " And " +
                    " A.room_id = " + i_room_id.ToString() + " And " +
                    " A.bed_id = " + i_bed_id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int iBedID = Int32.Parse(myReader[0].ToString());
                    int iRoomID = Int32.Parse(myReader[1].ToString());
                    int iRegionID = Int32.Parse(myReader[2].ToString());
                    string strBedName = myReader[3].ToString();
                    string strRoomName = myReader[4].ToString();
                    string strRegionName = myReader[5].ToString();
                    string strNote = myReader.IsDBNull(6) ? " " : myReader[6].ToString();
                    bool bInstall = bool.Parse(myReader[7].ToString());
                    int icurator = int.Parse(myReader[8].ToString());
                    string curator = myReader[9].ToString();
                    Bi = new BedInfo(iBedID, iRoomID, iRegionID, strBedName, strRoomName, strRegionName, strNote, bInstall, icurator, curator);
                }
                myReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                return null;
            }
            return Bi;
        }

        public bool IsExistBedID(int i_bed_id, int i_room_id, int i_region_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Select Count(*) From BEDS  Where  region_id = ",
					i_region_id.ToString(),
					" And  room_id = ",
					i_room_id.ToString(),
					" And  bed_id = ",
					i_bed_id.ToString()
				});
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueBedID(int i_room_id, int i_region_id)
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(bed_id) As MaxValue  From BEDS  Where  region_id = " + i_region_id.ToString() + " And  room_id = " + i_room_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public bool InsertBedInfo(int i_bed_id, int i_room_id, int i_region_id, string str_bed_name, string str_note, bool b_install, int i_curator)
        {
            try
            {
                SqlCommand cmd = this.SqlConnect.CreateCommand();
                cmd.CommandText =
                    " Insert Into BEDS " +
                    " ( " +
                    " bed_id, " +
                    " room_id, " +
                    " region_id, " +
                    " bed_name, " +
                    " note, " +
                    " install, " +
                    " curator " +
                    " ) " +
                    " Values " +
                    " ( " +
                    " " + i_bed_id.ToString() + ", " +
                    " " + i_room_id.ToString() + ", " +
                    " " + i_region_id.ToString() + ", " +
                    " N'" + str_bed_name.Trim() + "', " +
                    " " + (str_note.Trim() == string.Empty ? "null" : "N'" + str_note + "'") + ", " +
                    " " + (b_install ? "1" : "0") + ", " +
                    " " + i_curator + " " +
                    " ) ";
                int iAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateBedInfo(int i_bed_id, int i_room_id, int i_region_id, string str_bed_name, string str_note, bool b_install, int icurator)
        {
            try
            {
                SqlCommand cmd = this.SqlConnect.CreateCommand();
                cmd.CommandText =
                    " Update BEDS " +
                    " Set " +
                    " bed_name = N'" + str_bed_name.Trim() + "', " +
                    " note = " + (str_note.Trim() == string.Empty ? "null" : " N'" + str_note.Trim() + "'") + ", " +
                    " install = " + (b_install ? "1" : "0") + " " +
                    " Where " +
                    " region_id = " + i_region_id.ToString() + " And " +
                    " room_id = " + i_room_id.ToString() + " And " +
                    " curator = " + icurator.ToString() + " And " +
                    " bed_id = " + i_bed_id.ToString();
                int iAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                return false;
            }
            return true;
        }
        public bool DeleteBedInfo(int i_bed_id, int i_room_id, int i_region_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Delete From BEDS  Where  region_id = ",
					i_region_id.ToString(),
					" And  room_id = ",
					i_room_id.ToString(),
					" And  bed_id = ",
					i_bed_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool IsExistBedsInRoom(int i_room_id, int i_region_id)
        {
            int num = 0;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From BEDS  Where  region_id = " + i_region_id.ToString() + " And  room_id = " + i_room_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public LocationArray ReaderLocationsOfRegion(int i_region_id)
        {
            LocationArray locationArray = new LocationArray();
            LocationArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select A.location_id, A.region_id, A.location_name, B.region_name, A.type_id, C.type_name, A.note, A.install  From LOCATIONS A, REGIONS B, LOCATION_TYPES C  Where  A.region_id = B.region_id And  A.type_id = C.type_id And  A.region_id = " + i_region_id.ToString() + "  Order By A.location_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_location_id = int.Parse(sqlDataReader[0].ToString());
                    int i_region_id2 = int.Parse(sqlDataReader[1].ToString());
                    string str_location_name = sqlDataReader[2].ToString();
                    string str_region_name = sqlDataReader[3].ToString();
                    int i_type_id = int.Parse(sqlDataReader[4].ToString());
                    string str_type_name = sqlDataReader[5].ToString();
                    string str_note = sqlDataReader.IsDBNull(6) ? " " : sqlDataReader[6].ToString();
                    bool b_install = bool.Parse(sqlDataReader[7].ToString());
                    LocationInfo li = new LocationInfo(i_location_id, i_region_id2, str_location_name, str_region_name, i_type_id, str_type_name, str_note, b_install);
                    locationArray.Add(li);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new LocationArray();
                return result;
            }
            result = locationArray;
            return result;
        }
        public LocationInfo ReaderLocationInfo(int i_location_id, int i_region_id)
        {
            LocationInfo locationInfo = null;
            LocationInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select A.location_id, A.region_id, A.location_name, B.region_name, A.type_id, C.type_name, A.note, A.install  From LOCATIONS A, REGIONS B, LOCATION_TYPES C  Where  A.region_id = B.region_id And  A.type_id = C.type_id And  A.region_id = " + i_region_id.ToString() + " And  A.location_id = " + i_location_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_location_id2 = int.Parse(sqlDataReader[0].ToString());
                    int i_region_id2 = int.Parse(sqlDataReader[1].ToString());
                    string str_location_name = sqlDataReader[2].ToString();
                    string str_region_name = sqlDataReader[3].ToString();
                    int i_type_id = int.Parse(sqlDataReader[4].ToString());
                    string str_type_name = sqlDataReader[5].ToString();
                    string str_note = sqlDataReader.IsDBNull(6) ? " " : sqlDataReader[6].ToString();
                    bool b_install = bool.Parse(sqlDataReader[7].ToString());
                    locationInfo = new LocationInfo(i_location_id2, i_region_id2, str_location_name, str_region_name, i_type_id, str_type_name, str_note, b_install);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = locationInfo;
            return result;
        }
        public bool IsExistLocationID(int i_location_id, int i_region_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From LOCATIONS  Where  region_id = " + i_region_id.ToString() + " And  location_id = " + i_location_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueLocationID(int i_region_id)
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(location_id) As MaxValue  From LOCATIONS  Where  region_id = " + i_region_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public bool InsertLocationInfo(int i_location_id, int i_region_id, string str_location_name, int i_type_id, string str_note, bool b_install)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into LOCATIONS  (  location_id,  region_id,  location_name,  type_id,  note,  install  )  Values  (  ",
					i_location_id.ToString(),
					",  ",
					i_region_id.ToString(),
					",  N'",
					str_location_name.Trim(),
					"',  ",
					i_type_id.ToString(),
					",  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					",  ",
					b_install ? "1" : "0",
					"  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateLocationInfo(int i_location_id, int i_region_id, string str_location_name, string str_note, bool b_install)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update LOCATIONS  Set  location_name = N'",
					str_location_name.Trim(),
					"',  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					",  install = ",
					b_install ? "1" : "0",
					"  Where  region_id = ",
					i_region_id.ToString(),
					" And  location_id = ",
					i_location_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool DeleteLocationInfo(int i_location_id, int i_region_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Delete From LOCATIONS  Where  region_id = " + i_region_id.ToString() + " And  location_id = " + i_location_id.ToString();
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool IsExistLocationsInRegion(int i_region_id)
        {
            int num = 0;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From LOCATIONS  Where  region_id = " + i_region_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public LocationTypeArray ReaderLocationTypes()
        {
            LocationTypeArray locationTypeArray = new LocationTypeArray();
            LocationTypeArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select type_id, type_name, note  From LOCATION_TYPES  Where type_id <> 0  Order By type_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_type_id = int.Parse(sqlDataReader[0].ToString());
                    string str_type_name = sqlDataReader[1].ToString();
                    string str_note = sqlDataReader.IsDBNull(2) ? " " : sqlDataReader[2].ToString();
                    LocationTypeInfo lTi = new LocationTypeInfo(i_type_id, str_type_name, str_note);
                    locationTypeArray.Add(lTi);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new LocationTypeArray();
                return result;
            }
            result = locationTypeArray;
            return result;
        }
        public ServiceInfo ReaderRoomsServiceOfRegion(int i_region_id)
        {
            ServiceInfo serviceInfo = new ServiceInfo(0, "No service", 0);
            ServiceInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select M.service_id, M.service_name,  (  Select Count(*)  From ROOMS  Where region_id = " + i_region_id.ToString() + "  ) As total  From  (  Select service_id, service_name  From SERVICES  Where service_id = 0  ) M ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_service_id = int.Parse(sqlDataReader[0].ToString());
                    string str_service_name = sqlDataReader[1].ToString();
                    int i_total = int.Parse(sqlDataReader[2].ToString());
                    serviceInfo = new ServiceInfo(i_service_id, str_service_name, i_total);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = serviceInfo;
                return result;
            }
            result = serviceInfo;
            return result;
        }
        public ServiceInfo ReaderLocationsServiceOfRegion(int i_region_id)
        {
            ServiceInfo serviceInfo = new ServiceInfo(1, "No service", 0);
            ServiceInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select M.service_id, M.service_name,  (  Select Count(*)  From LOCATIONS  Where region_id = " + i_region_id.ToString() + "  ) As total  From  (  Select service_id, service_name  From SERVICES  Where service_id = 1  ) M ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_service_id = int.Parse(sqlDataReader[0].ToString());
                    string str_service_name = sqlDataReader[1].ToString();
                    int i_total = int.Parse(sqlDataReader[2].ToString());
                    serviceInfo = new ServiceInfo(i_service_id, str_service_name, i_total);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = serviceInfo;
                return result;
            }
            result = serviceInfo;
            return result;
        }
        public ServiceArray ReaderServices()
        {
            ServiceArray serviceArray = new ServiceArray();
            ServiceArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select service_id, service_name  From SERVICES  Order By service_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_service_id = int.Parse(sqlDataReader[0].ToString());
                    string str_service_name = sqlDataReader[1].ToString();
                    ServiceInfo si = new ServiceInfo(i_service_id, str_service_name, 0);
                    serviceArray.Add(si);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new ServiceArray();
                return result;
            }
            result = serviceArray;
            return result;
        }
        public EmployeeArray ReaderEmployees()
        {
            EmployeeArray employeeArray = new EmployeeArray();
            EmployeeArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select A.employee_id, A.first_name, A.last_name, A.men_or_women, A.birth_date,  A.title, A.department_id, B.department_name, A.job_id, C.job_name, A.hire_date,  A.address, A.city, A.phone, A.note  From  EMPLOYEES A, DEPARTMENTS B, JOBS C  Where  A.department_id = B.department_id And  A.job_id = C.job_id  Order By A.employee_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_employee_id = int.Parse(sqlDataReader[0].ToString());
                    string str_first_name = sqlDataReader[1].ToString();
                    string str_last_name = sqlDataReader[2].ToString();
                    bool b_men_or_women = bool.Parse(sqlDataReader[3].ToString());
                    DateTime dt_birth_date = DateTime.Parse(sqlDataReader[4].ToString());
                    string str_title = (sqlDataReader[5].ToString().Trim() == string.Empty) ? "" : sqlDataReader[5].ToString().Trim();
                    int i_department_id = int.Parse(sqlDataReader[6].ToString());
                    string str_department_name = sqlDataReader[7].ToString().Trim();
                    int i_job_id = int.Parse(sqlDataReader[8].ToString());
                    string str_job_name = sqlDataReader[9].ToString().Trim();
                    DateTime dt_hire_date = DateTime.Parse(sqlDataReader[10].ToString());
                    string str_address = (sqlDataReader[11].ToString().Trim() == string.Empty) ? " " : sqlDataReader[11].ToString().Trim();
                    string str_city = (sqlDataReader[12].ToString().Trim() == string.Empty) ? " " : sqlDataReader[12].ToString().Trim();
                    string str_phone = (sqlDataReader[13].ToString().Trim() == string.Empty) ? " " : sqlDataReader[13].ToString().Trim();
                    string str_note = (sqlDataReader[14].ToString().Trim() == string.Empty) ? " " : sqlDataReader[14].ToString().Trim();
                    EmployeeInfo ei = new EmployeeInfo(i_employee_id, str_first_name, str_last_name, b_men_or_women, dt_birth_date, str_title, i_department_id, str_department_name, i_job_id, str_job_name, dt_hire_date, str_address, str_city, str_phone, str_note);
                    employeeArray.Add(ei);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new EmployeeArray();
                return result;
            }
            result = employeeArray;
            return result;
        }
        public EmployeeInfo ReaderEmployeeInfo(int i_employee_id)
        {
            EmployeeInfo employeeInfo = null;
            EmployeeInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select A.employee_id, A.first_name, A.last_name, A.men_or_women, A.birth_date,  A.title, A.department_id, B.department_name, A.job_id, C.job_name, A.hire_date,  A.address, A.city, A.phone, A.note  From  EMPLOYEES A, DEPARTMENTS B, JOBS C  Where  A.department_id = B.department_id And  A.job_id = C.job_id And  A.employee_id = " + i_employee_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_employee_id2 = int.Parse(sqlDataReader[0].ToString());
                    string str_first_name = sqlDataReader[1].ToString();
                    string str_last_name = sqlDataReader[2].ToString();
                    bool b_men_or_women = bool.Parse(sqlDataReader[3].ToString());
                    DateTime dt_birth_date = DateTime.Parse(sqlDataReader[4].ToString());
                    string str_title = (sqlDataReader[5].ToString().Trim() == string.Empty) ? "" : sqlDataReader[5].ToString().Trim();
                    int i_department_id = int.Parse(sqlDataReader[6].ToString());
                    string str_department_name = sqlDataReader[7].ToString().Trim();
                    int i_job_id = int.Parse(sqlDataReader[8].ToString());
                    string str_job_name = sqlDataReader[9].ToString().Trim();
                    DateTime dt_hire_date = DateTime.Parse(sqlDataReader[10].ToString());
                    string str_address = (sqlDataReader[11].ToString().Trim() == string.Empty) ? "" : sqlDataReader[11].ToString().Trim();
                    string str_city = (sqlDataReader[12].ToString().Trim() == string.Empty) ? "" : sqlDataReader[12].ToString().Trim();
                    string str_phone = (sqlDataReader[13].ToString().Trim() == string.Empty) ? "" : sqlDataReader[13].ToString().Trim();
                    string str_note = (sqlDataReader[14].ToString().Trim() == string.Empty) ? "" : sqlDataReader[14].ToString().Trim();
                    employeeInfo = new EmployeeInfo(i_employee_id2, str_first_name, str_last_name, b_men_or_women, dt_birth_date, str_title, i_department_id, str_department_name, i_job_id, str_job_name, dt_hire_date, str_address, str_city, str_phone, str_note);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = employeeInfo;
            return result;
        }
        public bool IsExistEmployeeID(int i_employee_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From EMPLOYEES  Where employee_id = " + i_employee_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueEmployeeID()
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(employee_id) As MaxValue From EMPLOYEES ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public bool InsertEmployeeInfo(int i_employee_id, string str_first_name, string str_last_name, bool b_men_or_women, DateTime dt_birth_date, string str_title, int i_department_id, int i_job_id, DateTime dt_hire_date, string str_address, string str_city, string str_phone, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into EMPLOYEES  (  employee_id,  first_name,  last_name,  men_or_women,  birth_date,  title,  department_id,  job_id,  hire_date,  address,  city,  phone,  note  )  Values  (  ",
					i_employee_id.ToString(),
					",  N'",
					str_first_name.Trim(),
					"',  N'",
					str_last_name.Trim(),
					"',  ",
					b_men_or_women ? "1" : "0",
					",  '",
					dt_birth_date.ToString("MM/dd/yyyy"),
					"',  N'",
					str_title,
					"',  ",
					i_department_id.ToString(),
					",  ",
					i_job_id.ToString(),
					",  '",
					dt_hire_date.ToString("MM/dd/yyyy"),
					"',  ",
					(str_address.Trim() == string.Empty) ? "null" : ("N'" + str_address + "'"),
					",  ",
					(str_city.Trim() == string.Empty) ? "null" : ("N'" + str_city + "'"),
					",  ",
					(str_phone.Trim() == string.Empty) ? "null" : ("'" + str_phone + "'"),
					",  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note + "'"),
					"  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateEmployeeInfo(int i_employee_id, string str_first_name, string str_last_name, bool b_men_or_women, DateTime dt_birth_date, string str_title, int i_department_id, int i_job_id, DateTime dt_hire_date, string str_address, string str_city, string str_phone, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update EMPLOYEES  Set  first_name = N'",
					str_first_name.Trim(),
					"',  last_name = N'",
					str_last_name.Trim(),
					"',  men_or_women = ",
					b_men_or_women ? "1" : "0",
					",  birth_date = '",
					dt_birth_date.ToString("MM/dd/yyyy"),
					"',  title = N'",
					str_title.Trim(),
					"',  department_id = ",
					i_department_id.ToString(),
					",  job_id = ",
					i_job_id.ToString(),
					",  hire_date = '",
					dt_hire_date.ToString("MM/dd/yyyy"),
					"',  address = ",
					(str_address.Trim() == string.Empty) ? "null" : ("N'" + str_address.Trim() + "'"),
					",  city = ",
					(str_city.Trim() == string.Empty) ? "null" : ("N'" + str_city.Trim() + "'"),
					",  phone = ",
					(str_phone.Trim() == string.Empty) ? "null" : ("'" + str_phone.Trim() + "'"),
					",  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					"  Where  employee_id = ",
					i_employee_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool DeleteEmployeeInfo(int i_employee_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Delete From EMPLOYEES  Where employee_id = " + i_employee_id.ToString();
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public DepartmentArray ReaderDepartments()
        {
            DepartmentArray departmentArray = new DepartmentArray();
            DepartmentArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select department_id, department_name, note  From DEPARTMENTS  Order By department_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_department_id = int.Parse(sqlDataReader[0].ToString());
                    string str_department_name = sqlDataReader[1].ToString().Trim();
                    string str_note = (sqlDataReader[2].ToString().Trim() == string.Empty) ? " " : sqlDataReader[2].ToString().Trim();
                    DepartmentInfo di = new DepartmentInfo(i_department_id, str_department_name, str_note);
                    departmentArray.Add(di);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new DepartmentArray();
                return result;
            }
            result = departmentArray;
            return result;
        }
        public DepartmentInfo ReaderDepartmentInfo(int i_department_id)
        {
            DepartmentInfo departmentInfo = null;
            DepartmentInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select department_id, department_name, note  From DEPARTMENTS  Where department_id = " + i_department_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_department_id2 = int.Parse(sqlDataReader[0].ToString());
                    string str_department_name = sqlDataReader[1].ToString().Trim();
                    string str_note = (sqlDataReader[2].ToString().Trim() == string.Empty) ? "" : sqlDataReader[2].ToString().Trim();
                    departmentInfo = new DepartmentInfo(i_department_id2, str_department_name, str_note);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = departmentInfo;
            return result;
        }
        public bool IsExistDepartmentID(int i_department_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From DEPARTMENTS  Where department_id = " + i_department_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueDepartmentID()
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(department_id) As MaxValue From DEPARTMENTS ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public bool InsertDepartmentInfo(int i_department_id, string str_department_name, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into DEPARTMENTS  (  department_id,  department_name,  note  )  Values  (  ",
					i_department_id.ToString(),
					",  N'",
					str_department_name.Trim(),
					"',  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note + "'"),
					"  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateDepartmentInfo(int i_department_id, string str_department_name, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update DEPARTMENTS  Set  department_name = N'",
					str_department_name.Trim(),
					"',  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					"  Where  department_id = ",
					i_department_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool DeleteDepartmentInfo(int i_department_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Delete From DEPARTMENTS  Where department_id = " + i_department_id.ToString();
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public JobArray ReaderJobs()
        {
            JobArray jobArray = new JobArray();
            JobArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select job_id, job_name, note  From JOBS  Order By job_id ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_job_id = int.Parse(sqlDataReader[0].ToString());
                    string str_job_name = sqlDataReader[1].ToString().Trim();
                    string str_note = (sqlDataReader[2].ToString().Trim() == string.Empty) ? " " : sqlDataReader[2].ToString().Trim();
                    JobInfo ji = new JobInfo(i_job_id, str_job_name, str_note);
                    jobArray.Add(ji);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new JobArray();
                return result;
            }
            result = jobArray;
            return result;
        }
        public JobInfo ReaderJobInfo(int i_job_id)
        {
            JobInfo jobInfo = null;
            JobInfo result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select job_id, job_name, note  From JOBS  Where job_id = " + i_job_id.ToString();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int i_job_id2 = int.Parse(sqlDataReader[0].ToString());
                    string str_job_name = sqlDataReader[1].ToString().Trim();
                    string str_note = (sqlDataReader[2].ToString().Trim() == string.Empty) ? "" : sqlDataReader[2].ToString().Trim();
                    jobInfo = new JobInfo(i_job_id2, str_job_name, str_note);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = null;
                return result;
            }
            result = jobInfo;
            return result;
        }
        public bool IsExistJobID(int i_job_id)
        {
            int num;
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Count(*) From JOBS  Where job_id = " + i_job_id.ToString();
                num = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = true;
                return result;
            }
            result = (num > 0);
            return result;
        }
        public int GetMaxValueJobID()
        {
            int num = 0;
            int result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Select Max(job_id) As MaxValue From JOBS ";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int num2 = sqlDataReader.IsDBNull(0) ? 0 : int.Parse(sqlDataReader.GetValue(0).ToString());
                    num = num2;
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = -1;
                return result;
            }
            result = num;
            return result;
        }
        public bool InsertJobInfo(int i_job_id, string str_job_name, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Insert Into JOBS  (  job_id,  job_name,  note  )  Values  (  ",
					i_job_id.ToString(),
					",  N'",
					str_job_name.Trim(),
					"',  ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note + "'"),
					"  ) "
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool UpdateJobInfo(int i_job_id, string str_job_name, string str_note)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = string.Concat(new string[]
				{
					" Update JOBS  Set  job_name = N'",
					str_job_name.Trim(),
					"',  note = ",
					(str_note.Trim() == string.Empty) ? "null" : ("N'" + str_note.Trim() + "'"),
					"  Where  job_id = ",
					i_job_id.ToString()
				});
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public bool DeleteJobInfo(int i_job_id)
        {
            bool result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                sqlCommand.CommandText = " Delete From JOBS  Where job_id = " + i_job_id.ToString();
                int num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public RegionExArray ReaderRegionsEx()
        {
            RegionExArray regionExArray = new RegionExArray();
            RegionExArray result;
            try
            {
                SqlCommand sqlCommand = this.SqlConnect.CreateCommand();
                var cmd = " Select region_id, region_name  From REGIONS ";//   Order By region_id ";
                bool hasRegion = false;
                SqlDataReader sqlDataReader;
                if (clsUtl.RIGHT != 1)
                {
                    sqlCommand.CommandText = " Select  [user_id],[bedids]  From users  where user_id= " + clsUtl.USER_ID;
                    sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        string[] strs = sqlDataReader[1].ToString().Split(',');
                        if (strs != null && strs.Length > 0)
                        {
                            for (int i = 0; i < strs.Length; i++)
                                if (i == 0)
                                    cmd += " where region_id =" + strs[i].Split('|')[0];
                                else
                                    cmd += "  or region_id =" + strs[i].Split('|')[0];

                            hasRegion = true;
                        }
                    }
                    sqlDataReader.Close();
                }
                if (hasRegion || clsUtl.RIGHT == 1)
                {
                    sqlCommand.CommandText = cmd + "  Order By region_id ";
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        int i_region_id = int.Parse(sqlDataReader[0].ToString());
                        string str_region_name = sqlDataReader[1].ToString();
                        regionExArray.Add(new RegionExInfo(i_region_id, str_region_name, new RoomExArray(), new LocationExArray()));
                    }
                    sqlDataReader.Close();
                    foreach (RegionExInfo regionExInfo in regionExArray)
                    {
                        SqlCommand sqlCommand2 = this.SqlConnect.CreateCommand();
                        sqlCommand2.CommandText = " Select room_id, room_name, note  From ROOMS  Where region_id = " + regionExInfo.iRegionID.ToString() + "  Order By room_id ";
                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        while (sqlDataReader2.Read())
                        {
                            int i_room_id = int.Parse(sqlDataReader2[0].ToString());
                            string str_room_name = sqlDataReader2[1].ToString();
                            string str_room_note = sqlDataReader2[2].ToString();
                            regionExInfo.Rooms.Add(new RoomExInfo(i_room_id, str_room_name, str_room_note, new BedExArray()));
                        }
                        sqlDataReader2.Close();
                        foreach (RoomExInfo roomExInfo in regionExInfo.Rooms)
                        {
                            SqlCommand sqlCommand3 = this.SqlConnect.CreateCommand();
                            sqlCommand3.CommandText = string.Concat(new string[]
						{
							" Select bed_id, bed_name, note, install  From BEDS  Where  region_id = ",
							regionExInfo.iRegionID.ToString(),
							" And  room_id = ",
							roomExInfo.iRoomID.ToString(),
							"  Order By bed_id "
						});
                            SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                            while (sqlDataReader3.Read())
                            {
                                int i_bed_id = int.Parse(sqlDataReader3[0].ToString());
                                string str_bed_name = sqlDataReader3[1].ToString();
                                string str_bed_note = sqlDataReader3[2].ToString();
                                bool b_install = bool.Parse(sqlDataReader3[3].ToString());
                                roomExInfo.Beds.Add(new BedExInfo(i_bed_id, str_bed_name, str_bed_note, b_install, 1));
                            }
                            sqlDataReader3.Close();
                        }
                        SqlCommand sqlCommand4 = this.SqlConnect.CreateCommand();
                        sqlCommand4.CommandText = " Select location_id, location_name  From LOCATIONS  Where region_id = " + regionExInfo.iRegionID.ToString() + "  Order By location_id ";
                        SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
                        while (sqlDataReader4.Read())
                        {
                            int i_location_id = int.Parse(sqlDataReader4[0].ToString());
                            string str_location_name = sqlDataReader4[1].ToString();
                            regionExInfo.Locations.Add(new LocationExInfo(i_location_id, str_location_name));
                        }
                        sqlDataReader4.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new RegionExArray();
                return result;
            }
            result = regionExArray;
            return result;
        }
    }
}
