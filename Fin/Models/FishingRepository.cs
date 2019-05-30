using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Models
{
    public class FishingRepository : IFishingRepository
    {
        //public FishingRepository()
        //{
        //    FishingSearch fishingSearchObj=new FishingSearch();
        //    _fishingInfoList = new List<FishingInfo>();

        //    using (SqlConnection con = new SqlConnection(strConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("Get_FishingInfo", con);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;

        //        command.Parameters.AddWithValue("@is_YouthOnly", fishingSearchObj.Is_YouthOnly == false ? (bool?)null : fishingSearchObj.Is_YouthOnly);
        //        command.Parameters.AddWithValue("@is_YouthFriendly", fishingSearchObj.Is_YouthFriendly == false ? (bool?)null : fishingSearchObj.Is_YouthFriendly);
        //        command.Parameters.AddWithValue("@zipcode", fishingSearchObj.Zipcode);
        //        command.Parameters.AddWithValue("@fishSpecies_ID", fishingSearchObj.FishSpecies_ID == 0 ? (int?)null : fishingSearchObj.FishSpecies_ID);
        //        command.Parameters.AddWithValue("@fishSize_ID", fishingSearchObj.FishSize_ID == 0 ? (int?)null : fishingSearchObj.FishSize_ID);

        //        if (con.State == System.Data.ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }

        //        SqlDataReader dataReader = command.ExecuteReader();
        //        while (dataReader.Read())
        //        {
        //            FishingInfo fishingInfoObj = new FishingInfo();

        //            //Waterbody Details
        //            //**************************************************************************************************
        //            fishingInfoObj.Waterbody_ID = Convert.ToInt32(dataReader["Waterbody_ID"]);
        //            fishingInfoObj.WaterBody_AltName = dataReader["WaterBody_AltName"].ToString();
        //            fishingInfoObj.WaterBody_Description = dataReader["WaterBody_Description"].ToString();
        //            fishingInfoObj.Is_YouthFriendly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
        //            fishingInfoObj.Is_YouthOnly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
        //            fishingInfoObj.Street_Address = dataReader["Street_Address"].ToString();
        //            fishingInfoObj.City_or_County = dataReader["City_or_County"].ToString();
        //            fishingInfoObj.State = dataReader["State"].ToString();
        //            fishingInfoObj.Zipcode = dataReader["Zipcode"].ToString();
        //            //**************************************************************************************************

        //            //Waterbody Stocking Details
        //            //**************************************************************************************************
        //            fishingInfoObj.FishSpecies_Name = dataReader["FishSpecies_Name"].ToString();
        //            //**************************************************************************************************

        //            _fishingInfoList.Add(fishingInfoObj);
        //        }
        //    }
        //    //return _fishingInfoList;
        //}

        static string strConnectionString = "User Id=LIAdmin;Password=B!gF!shy!;Server=lisqlserver.database.windows.net;Database=Fin_DW;";


        public FishingSearch GetFishingSearch()
        {
            FishingSearch FishingSearchObj = new FishingSearch();    

            return FishingSearchObj;
        }


        /// <summary>
        /// Get Fishing Minimal Info
        /// </summary>
        /// <param name="fishingSearchObj"></param>
        /// <returns></returns>
        public IEnumerable<FishingInfo> GetFishingInfo()
        {
            FishingSearch fishingSearchObj = new FishingSearch();
            //fishingSearchObj.Zipcode = "97322";
            List<FishingInfo> _fishingInfoList = new List<FishingInfo>();

            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("Get_FishingInfo", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@is_YouthOnly", fishingSearchObj.Is_YouthOnly == false ? (bool?)null : fishingSearchObj.Is_YouthOnly);
                command.Parameters.AddWithValue("@is_YouthFriendly", fishingSearchObj.Is_YouthFriendly == false ? (bool?)null : fishingSearchObj.Is_YouthFriendly);
                command.Parameters.AddWithValue("@zipcode", fishingSearchObj.Zipcode);
                command.Parameters.AddWithValue("@fishSpecies_ID", fishingSearchObj.FishSpecies_ID == 0 ? (int?)null : fishingSearchObj.FishSpecies_ID);
                command.Parameters.AddWithValue("@fishSize_ID", fishingSearchObj.FishSize_ID == 0 ? (int?)null : fishingSearchObj.FishSize_ID);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    FishingInfo fishingInfoObj = new FishingInfo();

                    //Waterbody Details
                    //**************************************************************************************************
                    fishingInfoObj.Waterbody_ID = Convert.ToInt32(dataReader["Waterbody_ID"]);
                    fishingInfoObj.WaterBody_Image = "https://listorageaccount.blob.core.windows.net/finwaterbodyimages/" + dataReader["WaterBody_AltName"].ToString() + ".jpg";
                    fishingInfoObj.GPSCOORDINATES_DECIMAL = dataReader["GPSCOORDINATES_DECIMAL"].ToString();
                    fishingInfoObj.WaterBody_AltName = dataReader["WaterBody_AltName"].ToString();
                    fishingInfoObj.WaterBody_Description = dataReader["WaterBody_Description"].ToString();
                    fishingInfoObj.Is_YouthFriendly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoObj.Is_YouthOnly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoObj.Street_Address = dataReader["Street_Address"].ToString();
                    fishingInfoObj.City_or_County = dataReader["City_or_County"].ToString();
                    fishingInfoObj.State = dataReader["State"].ToString();
                    fishingInfoObj.Zipcode = dataReader["Zipcode"].ToString();
                    //**************************************************************************************************

                    //Waterbody Stocking Details
                    //**************************************************************************************************
                    fishingInfoObj.FishSpecies_Name = dataReader["FishSpecies_Name"].ToString();
                    //**************************************************************************************************

                    _fishingInfoList.Add(fishingInfoObj);
                }
            }
            return _fishingInfoList;
        }

        /// <summary>
        /// Get Fishing Minimal Info
        /// </summary>
        /// <param name="fishingSearchObj"></param>
        /// <returns></returns>
        public IEnumerable<FishingInfo> GetFishingInfo(FishingSearch FishingSearchObj)
        {
            
            List<FishingInfo> _fishingInfoList = new List<FishingInfo>();

            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("Get_FishingInfo", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@is_YouthOnly", FishingSearchObj.Is_YouthOnly == false ? (bool?)null : FishingSearchObj.Is_YouthOnly);
                command.Parameters.AddWithValue("@is_YouthFriendly", FishingSearchObj.Is_YouthFriendly == false ? (bool?)null : FishingSearchObj.Is_YouthFriendly);
                command.Parameters.AddWithValue("@zipcode", FishingSearchObj.Zipcode);
                command.Parameters.AddWithValue("@fishSpecies_ID", FishingSearchObj.FishSpecies_ID == 0 ? (int?)null : FishingSearchObj.FishSpecies_ID);
                command.Parameters.AddWithValue("@fishSize_ID", FishingSearchObj.FishSize_ID == 0 ? (int?)null : FishingSearchObj.FishSize_ID);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    FishingInfo fishingInfoObj = new FishingInfo();

                    //Waterbody Details
                    //**************************************************************************************************
                    fishingInfoObj.Waterbody_ID = Convert.ToInt32(dataReader["Waterbody_ID"]);
                    fishingInfoObj.WaterBody_Image = "https://listorageaccount.blob.core.windows.net/finwaterbodyimages/" + dataReader["WaterBody_AltName"].ToString() + ".jpg";
                    fishingInfoObj.GPSCOORDINATES_DECIMAL = dataReader["GPSCOORDINATES_DECIMAL"].ToString();
                    fishingInfoObj.WaterBody_AltName = dataReader["WaterBody_AltName"].ToString();
                    fishingInfoObj.WaterBody_Description = dataReader["WaterBody_Description"].ToString();
                    fishingInfoObj.Is_YouthFriendly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoObj.Is_YouthOnly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoObj.Street_Address = dataReader["Street_Address"].ToString();
                    fishingInfoObj.City_or_County = dataReader["City_or_County"].ToString();
                    fishingInfoObj.State = dataReader["State"].ToString();
                    fishingInfoObj.Zipcode = dataReader["Zipcode"].ToString();
                    //**************************************************************************************************

                    //Waterbody Stocking Details
                    //**************************************************************************************************
                    fishingInfoObj.FishSpecies_Name = dataReader["FishSpecies_Name"].ToString();
                    //**************************************************************************************************

                    _fishingInfoList.Add(fishingInfoObj);
                }
            }
            return _fishingInfoList;
        }

        /// <summary>
        /// Get Detailed Info about Fishing
        /// </summary>
        /// <param name="WaterBodyId"></param>
        /// <returns></returns>
        public FishingInfoDetail GetFishingDetailInfo(int WaterBodyId)
        {
            FishingInfoDetail FishingInfoDetailObj = new FishingInfoDetail();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("Get_FishingInfoDetail", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@waterbody_ID", WaterBodyId);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    //Waterbody Details
                    //**************************************************************************************************
                    FishingInfoDetailObj.Waterbody_ID = Convert.ToInt32(dataReader["Waterbody_ID"]);
                    FishingInfoDetailObj.WaterBody_Image = "https://listorageaccount.blob.core.windows.net/finwaterbodyimages/"+dataReader["WaterBody_AltName"].ToString()+ ".jpg";
                    FishingInfoDetailObj.WaterBody_AltName = dataReader["WaterBody_AltName"].ToString();
                    FishingInfoDetailObj.WaterBody_Description = dataReader["WaterBody_Description"].ToString();
                    FishingInfoDetailObj.Is_YouthFriendly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    FishingInfoDetailObj.Is_YouthOnly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    FishingInfoDetailObj.Street_Address = dataReader["Street_Address"].ToString();
                    FishingInfoDetailObj.City_or_County = dataReader["City_or_County"].ToString();
                    FishingInfoDetailObj.State = dataReader["State"].ToString();
                    FishingInfoDetailObj.Zipcode = dataReader["Zipcode"].ToString();
                    FishingInfoDetailObj.Zone = dataReader["Zone"].ToString();
                    FishingInfoDetailObj.Office = dataReader["Office"].ToString();
                    FishingInfoDetailObj.WaterBody_Size = dataReader["WaterBody_Size"].ToString();
                    FishingInfoDetailObj.GPSCOORDINATES_DEGREES = dataReader["GPSCOORDINATES_DEGREES"].ToString();
                    FishingInfoDetailObj.GPSCOORDINATES_DECIMAL = dataReader["GPSCOORDINATES_DECIMAL"].ToString();
                    //**************************************************************************************************

                    //Waterbody Stocking Details
                    //**************************************************************************************************
                    FishingInfoDetailObj.FishSpecies_Name = dataReader["FishSpecies_Name"].ToString();
                    FishingInfoDetailObj.Stocking_StartDay = Convert.ToDateTime(dataReader["Stocking_StartDay"]);
                    FishingInfoDetailObj.Stocking_EndDay = Convert.ToDateTime(dataReader["Stocking_EndDay"]);
                    FishingInfoDetailObj.Legals = Convert.ToInt32(dataReader["Legals"]);
                    FishingInfoDetailObj.Trophy = Convert.ToInt32(dataReader["Trophy"]);
                    FishingInfoDetailObj.Brood = Convert.ToInt32(dataReader["Brood"]);
                    FishingInfoDetailObj.Total = Convert.ToInt32(dataReader["Total"]);
                    //**************************************************************************************************
                }
            }
            return FishingInfoDetailObj;
        }
    }
}
