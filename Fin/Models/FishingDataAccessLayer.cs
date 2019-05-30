using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Models
{
    public class FishingDataAccessLayer
    {
        static string strConnectionString = "User Id=LIAdmin;Password=B!gF!shy!;Server=lisqlserver.database.windows.net;Database=Fin_DW;";

        /// <summary>
        /// Get Fishing Info
        /// </summary>
        /// <param name="fishingSearchObj"></param>
        /// <returns></returns>
        public IEnumerable<FishingInfo> GetFishingInfo(FishingSearch fishingSearchObj)
        {
            List<FishingInfo> FishingInfoListObj = new List<FishingInfo>();
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
                    fishingInfoObj.Waterbody_ID = Convert.ToInt32(dataReader["Waterbody_ID"]);
                    fishingInfoObj.WaterBody_AltName = dataReader["WaterBody_AltName"].ToString();
                    fishingInfoObj.WaterBody_Description = dataReader["WaterBody_Description"].ToString();
                    fishingInfoObj.Is_YouthFriendly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoObj.Is_YouthOnly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoObj.Street_Address = dataReader["Street_Address"].ToString();
                    fishingInfoObj.City_or_County = dataReader["City_or_County"].ToString();
                    fishingInfoObj.State = dataReader["State"].ToString();
                    fishingInfoObj.Zipcode = dataReader["Zipcode"].ToString();
                    fishingInfoObj.FishSpecies_Name = dataReader["FishSpecies_Name"].ToString();
                    FishingInfoListObj.Add(fishingInfoObj);
                }
            }
            return FishingInfoListObj;
        }


        /// <summary>
        /// Get Fishing Info
        /// </summary>
        /// <param name="fishingSearchObj"></param>
        /// <returns></returns>
        public FishingInfoDetail GetFishingDetailInfo(int WaterBodyId)
        {
            FishingInfoDetail fishingInfoDetailObj = new FishingInfoDetail();
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

                    fishingInfoDetailObj.Waterbody_ID = Convert.ToInt32(dataReader["Waterbody_ID"]);
                    fishingInfoDetailObj.WaterBody_AltName = dataReader["WaterBody_AltName"].ToString();
                    fishingInfoDetailObj.WaterBody_Description = dataReader["WaterBody_Description"].ToString();
                    fishingInfoDetailObj.Is_YouthFriendly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoDetailObj.Is_YouthOnly = Convert.ToBoolean(dataReader["Is_YouthOnly"]);
                    fishingInfoDetailObj.Street_Address = dataReader["Street_Address"].ToString();
                    fishingInfoDetailObj.City_or_County = dataReader["City_or_County"].ToString();
                    fishingInfoDetailObj.State = dataReader["State"].ToString();
                    fishingInfoDetailObj.Zipcode = dataReader["Zipcode"].ToString();
                    fishingInfoDetailObj.FishSpecies_Name = dataReader["FishSpecies_Name"].ToString();

                    fishingInfoDetailObj.Zone = dataReader["Zone"].ToString();
                    fishingInfoDetailObj.Office = dataReader["Office"].ToString();
                    fishingInfoDetailObj.WaterBody_Size = dataReader["WaterBody_Size"].ToString();

                    fishingInfoDetailObj.GPSCOORDINATES_DEGREES = dataReader["GPSCOORDINATES_DEGREES"].ToString();
                    fishingInfoDetailObj.GPSCOORDINATES_DECIMAL = dataReader["GPSCOORDINATES_DECIMAL"].ToString();

                    fishingInfoDetailObj.Stocking_StartDay = Convert.ToDateTime(dataReader["Stocking_StartDay"]);
                    fishingInfoDetailObj.Stocking_EndDay = Convert.ToDateTime(dataReader["Stocking_EndDay"]);

                    fishingInfoDetailObj.Legals = Convert.ToInt32(dataReader["Legals"]);
                    fishingInfoDetailObj.Trophy = Convert.ToInt32(dataReader["Trophy"]);
                    fishingInfoDetailObj.Brood = Convert.ToInt32(dataReader["Brood"]);
                    fishingInfoDetailObj.Total = Convert.ToInt32(dataReader["Total"]);


                }
            }
            return fishingInfoDetailObj;
        }

    }
}
