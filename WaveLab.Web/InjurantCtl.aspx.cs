﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class InjurantCtl : CommonPage
    {
        private Hashtable equalHashTable = new Hashtable();
        private Hashtable hashTable = new Hashtable();
        private IInjurantService service;
        private IInjurantTypeService typeService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IInjurantService)cxt.GetObject("SV.InjurantService");
            typeService = (IInjurantTypeService)cxt.GetObject("SV.InjurantTypeService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();
                BindResult();
            }
        }

        private void LoadCriteria()
        {

            this.ddlInjurantType.DataSource = typeService.GetItems(new Hashtable(), "injurant_type_desc", "asc");
            this.ddlInjurantType.DataValueField = "InjurantTypeId";
            this.ddlInjurantType.DataTextField = "InjurantTypeDesc";
            this.ddlInjurantType.DataBind();
            this.ddlInjurantType.Items.Insert(0, new ListItem("", ""));

            if (string.IsNullOrEmpty(Request.QueryString["injurant_type_id"]) == false)
            {
                this.ddlInjurantType.SelectedValue = Request.QueryString["injurant_type_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["injurant_desc_en"]) == false)
            {
                this.tbxInjurantDescEn.Text = Request.QueryString["injurant_desc_en"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["injurant_desc_cn"]) == false)
            {
                this.tbxInjurantDescCn.Text = Request.QueryString["injurant_desc_cn"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["molecular_formula"]) == false)
            {
                this.tbxMolecularFormula.Text = Request.QueryString["molecular_formula"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["cas_no"]) == false)
            {
                this.tbxCasNo.Text = Request.QueryString["cas_no"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "injurant_type_desc,injurant_desc_cn";
            }

            if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
            {
                ViewState["orderby"] = Request.QueryString["ob"].ToString();
            }
            else
            {
                ViewState["orderby"] = "asc";
            }
        }

        private void GetSearchCriteria()
        {
            if (this.ddlInjurantType.SelectedValue.Trim().Length > 0)
            {
                equalHashTable.Add("injurant_type_id", this.ddlInjurantType.SelectedValue.Trim());
            }
            if (this.tbxInjurantDescEn.Text.Trim().Length > 0)
            {
                hashTable.Add("injurant_desc_en", this.tbxInjurantDescEn.Text.Trim());
            }

            if (this.tbxInjurantDescCn.Text.Trim().Length > 0)
            {
                hashTable.Add("injurant_desc_cn", this.tbxInjurantDescCn.Text.Trim());
            }

            if (this.tbxMolecularFormula.Text.Trim().Length > 0)
            {
                hashTable.Add("molecular_formula", this.tbxMolecularFormula.Text.Trim());
            }

            if (this.tbxCasNo.Text.Trim().Length > 0)
            {
                hashTable.Add("cas_no", this.tbxCasNo.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<InjurantInfo> items = service.GetItems(equalHashTable,hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
                this.PagerNavigator.Visible = false;

            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.PagerNavigator.Visible = true;
                this.PagerNavigator.RecordCount = items.Count;
                if (!Page.IsPostBack && string.IsNullOrEmpty(Request.QueryString["page"]) == false)
                {
                    this.PagerNavigator.CurrentPageIndex = int.Parse(Request.QueryString["page"]);
                }

                var pageItems =
                (
                  from item in items
                  select item
                ).Skip(this.PagerNavigator.PageSize * (this.PagerNavigator.CurrentPageIndex - 1)).Take(this.PagerNavigator.PageSize);

                this.GVList.DataSource = pageItems;
                this.GVList.DataBind();

            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("InjurantCtl.aspx?1=1");
            foreach (DictionaryEntry item in equalHashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value.ToString());
            }
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value.ToString());
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);
            builder.Append("&page=" + this.PagerNavigator.CurrentPageIndex);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
        }

        protected void GVList_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["sortby"].ToString() == e.SortExpression)
            {
                if (ViewState["orderby"].ToString() == "asc")
                {
                    ViewState["orderby"] = "desc";
                }
                else
                {
                    ViewState["orderby"] = "asc";
                }
            }
            else
            {
                ViewState["sortby"] = e.SortExpression;
            }
            this.BindResult();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

    }
}
