using System;
using System.Collections;
using System.Data.SqlClient;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
namespace HTGSL
{
    public class clsSound : IDisposable
    {
        private ArrayList alInput;
        private SoundExArray SoundArray = new SoundExArray();
        private SoundTempArray SoundTmpArray = new SoundTempArray();
        private static string sTemplate_Code = "1";
        public static string SoundTemplate
        {
            get
            {
                return clsSound.sTemplate_Code;
            }
            set
            {
                clsSound.sTemplate_Code = value;
            }
        }
        public clsSound()
        {
            this.alInput = new ArrayList();
            this.SoundArray = this.LoadSound();
        }
        public void AddInput(string Field_Name, string Type)
        {
            this.alInput.Add(Field_Name);
            this.alInput.Add(Type);
        }
        public void PlaySound()
        {
            string text = "";
            string a = "";
            DataProvider dataProvider = new DataProvider();
            int length = text.Length;
            if (this.alInput.Count > 0)
            {
                for (int i = 0; i < this.alInput.Count - 1; i += 2)
                {
                    if (this.alInput[i + 1].ToString() == "1")
                    {
                        text = this.alInput[i].ToString().Trim();
                        length = text.Length;
                        for (int j = 0; j < length; j++)
                        {
                            string str = text.Substring(j, 1);
                            string sqlString = "SELECT FILE_AM_THANH FROM AM_THANH WHERE AM_THANH_ID = '" + str + "'";
                            SqlDataReader sqlDataReader = dataProvider.excuteQuery(sqlString);
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    a = sqlDataReader["FILE_AM_THANH"].ToString();
                                }
                            }
                            if (a == "")
                            {
                                MessageBox.Show("Thiếu file âm thanh " + str);
                                break;
                            }
                        }
                    }
                    if (this.alInput[i + 1].ToString() == "2")
                    {
                        string pattern = " ";
                        Regex regex = new Regex(pattern);
                        string[] array = regex.Split(this.alInput[i].ToString());
                        string[] array2 = array;
                        for (int k = 0; k < array2.Length; k++)
                        {
                            string str2 = array2[k];
                            string sqlString = "SELECT FILE_AM_THANH FROM AM_THANH WHERE AM_THANH_ID = '" + str2 + "'";
                            SqlDataReader sqlDataReader = dataProvider.excuteQuery(sqlString);
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    a = sqlDataReader["FILE_AM_THANH"].ToString();
                                }
                            }
                            if (a == "")
                            {
                                MessageBox.Show("Thiếu file âm thanh " + str2);
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void PlaySound(string sRegion, string sRoom, string sBed)
        {
        }
        public void PlaySoundWav(string sRegion, string sRoom, string sBed)
        {
            int num = 0;
            string text = "";
            ArrayList arrayList = new ArrayList();
            SoundPlayer soundPlayer = new SoundPlayer();
            foreach (SoundTempInfo soundTempInfo in this.SoundTmpArray)
            {
                switch (soundTempInfo.iSound_type_id)
                {
                    case 1:
                        try
                        {
                            text = this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                        }
                        catch
                        {
                            text = "";
                        }
                        if (text.Length > 0)
                        {
                            arrayList.Add(text);
                        }
                        try
                        {
                            text = this.SoundArray.GetValue(sRegion).sound_path;
                        }
                        catch
                        {
                            text = "";
                        }
                        if (text.Length > 0)
                        {
                            arrayList.Add(text);
                        }
                        break;

                    case 2:
                        try
                        {
                            text = this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                        }
                        catch
                        {
                            text = "";
                        }
                        if (text.Length > 0)
                        {
                            arrayList.Add(text);
                        }
                        num = sRoom.Length;
                        if (soundTempInfo.iNread > 0)
                        {
                            if (soundTempInfo.iNread <= num)
                            {
                                sRoom = sRoom.Substring(num - soundTempInfo.iNread, soundTempInfo.iNread);
                            }
                        }
                        num = sRoom.Length;
                        for (int i = 0; i < num; i++)
                        {
                            string s_sound_code = sRoom.Substring(i, 1);
                            try
                            {
                                text = this.SoundArray.GetValue(s_sound_code).sound_path;
                            }
                            catch
                            {
                                text = "";
                            }
                            if (text.Length > 0)
                            {
                                arrayList.Add(text);
                            }
                        }
                        break;

                    case 3:
                        if (sBed == "00")
                        {
                            try
                            {
                                text = this.SoundArray.GetValue(sBed).sound_path;
                            }
                            catch
                            {
                                text = "";
                            }
                            if (text.Length > 0)
                            {
                                arrayList.Add(text);
                            }
                        }
                        else
                        {
                            try
                            {
                                text = this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                            }
                            catch
                            {
                                text = "";
                            }
                            if (text.Length > 0)
                            {
                                arrayList.Add(text);
                            }
                            num = sBed.Length;
                            if (soundTempInfo.iNread > 0)
                            {
                                if (soundTempInfo.iNread <= num)
                                {
                                    sBed = sBed.Substring(num - soundTempInfo.iNread, soundTempInfo.iNread);
                                }
                            }
                            num = sBed.Length;
                            for (int i = 0; i < num; i++)
                            {
                                string s_sound_code = sBed.Substring(i, 1);
                                try
                                {
                                    text = this.SoundArray.GetValue(s_sound_code).sound_path;
                                }
                                catch
                                {
                                    text = "";
                                }
                                if (text.Length > 0)
                                {
                                    arrayList.Add(text);
                                }
                            }
                        }
                        break;

                    case 4:
                        if (soundTempInfo.iSound_id.ToString() != "")
                        {
                            try
                            {
                                text = this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                            }
                            catch
                            {
                                text = "";
                            }
                            if (text.Length > 0)
                            {
                                arrayList.Add(text);
                            }
                        }
                        break;
                }
            }
            for (int j = 0; j < arrayList.Count; j++)
            {
                try
                {
                    int soundLength = SoundInfo.GetSoundLength(arrayList[j].ToString());
                    soundPlayer.SoundLocation = arrayList[j].ToString();
                    soundPlayer.Play();
                    Thread.Sleep(soundLength);
                }
                catch
                {
                }
            }
        }

        public string GetSoundToPlay(string sRegion, string sRoom, string sBed)
        {
            int num = 0;
            string text = "";
            foreach (SoundTempInfo soundTempInfo in this.SoundTmpArray)
            {
                switch (soundTempInfo.iSound_type_id)
                {
                    case 1:
                        #region
                        try
                        {
                            text += this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                        }
                        catch { }
                        try
                        {
                            text += this.SoundArray.GetValue(sRegion).sound_path;
                        }
                        catch { }
                        #endregion
                        break;
                    case 2:
                        #region
                        try
                        {
                            text += this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                        }
                        catch { }

                        num = sRoom.Length;
                        if (soundTempInfo.iNread > 0)
                        {
                            if (soundTempInfo.iNread <= num)
                            {
                                sRoom = sRoom.Substring(num - soundTempInfo.iNread, soundTempInfo.iNread);
                            }
                        }
                        num = sRoom.Length;
                        if (num > 0)
                        {
                            text += "|";
                            for (int i = 0; i < num; i++)
                            {
                                string s_sound_code = sRoom.Substring(i, 1);
                                try
                                {
                                    text += this.SoundArray.GetValue(s_sound_code).sound_path;
                                    if (i < num)
                                        text += "|";
                                }
                                catch
                                { }
                                if (text.Length > 0)
                                { }
                            }
                        }
                        #endregion
                        break;
                    case 3:
                        #region
                        if (sBed == "00")
                        {
                            try
                            {
                                text += this.SoundArray.GetValue(sBed).sound_path;
                            }
                            catch
                            { }
                        }
                        else
                        {
                            try
                            {
                                text += this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                            }
                            catch
                            { }
                            num = sBed.Length;
                            if (soundTempInfo.iNread > 0)
                            {
                                if (soundTempInfo.iNread <= num)
                                {
                                    sBed = sBed.Substring(num - soundTempInfo.iNread, soundTempInfo.iNread);
                                }
                            }
                            num = sBed.Length;
                            if (num > 0)
                            {
                                text += "|";
                                for (int i = 0; i < num; i++)
                                {
                                    string s_sound_code = sBed.Substring(i, 1);
                                    try
                                    {
                                        text += this.SoundArray.GetValue(s_sound_code).sound_path;
                                        if (i < num)
                                            text += "|";
                                    }
                                    catch
                                    { }
                                }
                            }

                        }
                        #endregion
                        break;
                    case 4:
                        if (soundTempInfo.iSound_id.ToString() != "")
                            try
                            {
                                text += this.SoundArray.GetValue(int.Parse(soundTempInfo.iSound_id.ToString())).sound_path;
                            }
                            catch { }
                        break;
                }
                text += "|";
            }
            return text;
        }

        public void Close()
        {
            try
            {
            }
            catch (Exception)
            {
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private SoundExArray LoadSound()
        {
            SoundExArray soundExArray = new SoundExArray();
            SoundExArray result;
            try
            {
                DataProvider dataProvider = new DataProvider();
                string sqlString = "SELECT [sound_id],[sound_code] ,[sound_type] ,[sound_path] FROM  [dbo].[SOUNDS]Order by sound_id;";
                SqlDataReader sqlDataReader = dataProvider.excuteQuery(sqlString);
                while (sqlDataReader.Read())
                {
                    int i_sound_id = int.Parse(sqlDataReader[0].ToString());
                    string s_sound_code = sqlDataReader[1].ToString();
                    int i_sound_type;
                    if (sqlDataReader[2].ToString() != "")
                    {
                        i_sound_type = int.Parse(sqlDataReader[2].ToString());
                    }
                    else
                    {
                        i_sound_type = 0;
                    }
                    string s_sound_path = sqlDataReader[3].ToString();
                    SoundExInfo si = new SoundExInfo(i_sound_id, s_sound_code, i_sound_type, s_sound_path);
                    soundExArray.Add(si);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new SoundExArray();
                return result;
            }
            result = soundExArray;
            return result;
        }
        private SoundTempArray LoadSoundTemplate()
        {
            SoundTempArray soundTempArray = new SoundTempArray();
            SoundTempArray result;
            try
            {
                DataProvider dataProvider = new DataProvider();
                string sqlString = "SELECT [sound_template_id],[sound_template_code],[sound_type_id],[sound_id] FROM  [dbo].[SOUND_TEMPLATES]";
                SqlDataReader sqlDataReader = dataProvider.excuteQuery(sqlString);
                while (sqlDataReader.Read())
                {
                    int isound_template_id = int.Parse(sqlDataReader[0].ToString());
                    string ssound_template_code = sqlDataReader[1].ToString();
                    int isound_type_id = int.Parse(sqlDataReader[2].ToString());
                    int isound_id = sqlDataReader.IsDBNull(3) ? 0 : int.Parse(sqlDataReader[3].ToString());
                    SoundTempInfo si = new SoundTempInfo(isound_template_id, ssound_template_code, isound_type_id, isound_id);
                    soundTempArray.Add(si);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new SoundTempArray();
                return result;
            }
            result = soundTempArray;
            return result;
        }
        private SoundTempArray LoadSoundTemplate(string sSound_template_code)
        {
            SoundTempArray soundTempArray = new SoundTempArray();
            SoundTempArray result;
            try
            {
                DataProvider dataProvider = new DataProvider();
                string sqlString = "SELECT [sound_template_id],[sound_template_code],[sound_type_id],[sound_id], [nreads] FROM  [dbo].[SOUND_TEMPLATES]WHERE sound_template_code = '" + sSound_template_code + "' Order By [orderby]";
                SqlDataReader sqlDataReader = dataProvider.excuteQuery(sqlString);
                while (sqlDataReader.Read())
                {
                    int isound_template_id = int.Parse(sqlDataReader[0].ToString());
                    string ssound_template_code = sqlDataReader[1].ToString();
                    int isound_type_id = int.Parse(sqlDataReader[2].ToString());
                    int isound_id = sqlDataReader.IsDBNull(3) ? 0 : int.Parse(sqlDataReader[3].ToString());
                    int inread = sqlDataReader.IsDBNull(4) ? 0 : int.Parse(sqlDataReader[4].ToString());
                    SoundTempInfo si = new SoundTempInfo(isound_template_id, ssound_template_code, isound_type_id, isound_id, inread);
                    soundTempArray.Add(si);
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MyMsgBox.MsgError(ex.Message);
                result = new SoundTempArray();
                return result;
            }
            result = soundTempArray;
            return result;
        }
        public void SetSoundTemplate(string sSoundTemplate)
        {
            this.SoundTmpArray = this.LoadSoundTemplate(sSoundTemplate);
        }
        private string ReadSoundFile(int iSound_id)
        {
            return this.SoundArray.GetIndex(iSound_id).ToString();
        }
        private string ReadSoundFile(string sSound_code)
        {
            return this.SoundArray.GetValue("8").ToString();
        }
    }
}
