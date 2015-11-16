using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class ChartOfAccountGroupBase
	{
		protected static Balancika.DAL.ChartOfAccountGroupDal dal = new Balancika.DAL.ChartOfAccountGroupDal();

		public System.Int32 CoaGroupId		{ get ; set; }

		public System.String CoaGroupName		{ get ; set; }

		public System.Int32 ParentId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }


		public  Int32 InsertChartOfAccountGroup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaGroupId", CoaGroupId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CoaGroupName", CoaGroupName);
			lstItems.Add("@ParentId", ParentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertChartOfAccountGroup(lstItems);
		}

		public  Int32 UpdateChartOfAccountGroup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaGroupId", CoaGroupId.ToString());
			lstItems.Add("@CoaGroupName", CoaGroupName);
			lstItems.Add("@ParentId", ParentId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString());

			return dal.UpdateChartOfAccountGroup(lstItems);
		}

		public  Int32 DeleteChartOfAccountGroupByCoaGroupId(Int32 CoaGroupId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaGroupId", CoaGroupId);

			return dal.DeleteChartOfAccountGroupByCoaGroupId(lstItems);
		}

		public List<ChartOfAccountGroup> GetAllChartOfAccountGroup(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllChartOfAccountGroup(lstItems);
			List<ChartOfAccountGroup> ChartOfAccountGroupList = new List<ChartOfAccountGroup>();
			foreach (DataRow dr in dt.Rows)
			{
				ChartOfAccountGroupList.Add(GetObject(dr));
			}
			return ChartOfAccountGroupList;
		}

		public ChartOfAccountGroup GetChartOfAccountGroupByCoaGroupId(int _CoaGroupId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaGroupId", _CoaGroupId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetChartOfAccountGroupByCoaGroupId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ChartOfAccountGroup GetObject(DataRow dr)
		{

			ChartOfAccountGroup objChartOfAccountGroup = new ChartOfAccountGroup();
			objChartOfAccountGroup.CoaGroupId = (dr["CoaGroupId"] == DBNull.Value) ? 0 : (Int32)dr["CoaGroupId"];
			objChartOfAccountGroup.CoaGroupName = (dr["CoaGroupName"] == DBNull.Value) ? "" : (String)dr["CoaGroupName"];
			objChartOfAccountGroup.ParentId = (dr["ParentId"] == DBNull.Value) ? 0 : (Int32)dr["ParentId"];
			objChartOfAccountGroup.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objChartOfAccountGroup.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objChartOfAccountGroup.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objChartOfAccountGroup.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];

			return objChartOfAccountGroup;
		}
	}
}
