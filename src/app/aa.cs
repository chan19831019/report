 private void aa()
        {
            //1.未付款保案彙總報表(月/季報)
            //getUnpaidPlanSummaryReport();

            //3.未決賠款估算表(半年報)，提供未決賠款統計資料
            //getUnresolvedClaimsEstimateReport();

            //4.風險彙總(月報)
            //getSummaryOfRiskReport();

            //5.賠款明細表(月報)
            //getIndemnityScheduleReport();

            //6.理賠前收回明細表(月報)
            //getReport6();

            //7.理賠後收回明細表(月報)
            getReport7();

        }

        /// <summary>
        /// 未付款保案彙總報表(月/季報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void getUnpaidPlanSummaryReport()
        {
            DataTable m_summaryOfUnpaidPlanDT = new DataTable();
            if (m_summaryOfUnpaidPlanDT.Rows.Count == 0)
                return;

            string m_uid = string.Empty;
            g_count = 1;
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");
            g_stringBuilder.Append("<h6 style=\"margin-bottom: 5px;\">1.未付款保案彙總報表(月/季報)</h6>");
            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
            g_stringBuilder.Append("<thead>");
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "rowspan=\"2\"", "center", 2, "序號");
            setHtmlString("th", "rowspan=\"2\"", "center", 4, "註記");
            setHtmlString("th", "", "center", 6, "被保險人");
            setHtmlString("th", "", "center", 9, "本行承保始日<sup>2</sup>");
            setHtmlString("th", "", "center", 10, "傳統險出險筆數<br />/全球通出險金額");
            setHtmlString("th", "colspan=\"3\"", "center", 15, "買主或開狀銀行");
            setHtmlString("th", "", "center", 5, "進口國");
            setHtmlString("th", "rowspan=\"2\"", "center", 4, "未付款<br />原因<sup>3</sup>");
            setHtmlString("th", "rowspan=\"2\"", "center", 6, "上月可能<br /><br />理賠金額<sup>5</sup><br />NTD");
            setHtmlString("th", "rowspan=\"2\"", "center", 6, "本月可能<br /><br />理賠金額<br />NTD");
            setHtmlString("th", "rowspan=\"2\"", "center", 6, "信用保險<br /><br />金額異動<br />NTD");
            setHtmlString("th", "rowspan=\"2\"", "center", 24, "目          前          狀          況");
            setHtmlString("th", "rowspan=\"2\"", "center", 3, "經辦單位");

            g_stringBuilder.Append("</tr>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 6, "被保險人");
            setHtmlString("th", "", "center", 9, "本案出險日<SUP>4</SUP>");
            setHtmlString("th", "", "center", 10, "傳統險承保筆數<br />/全球通<br />歷年申報營業額");
            setHtmlString("th", "", "center", 6, "信用配額<br />/總信用限額");
            setHtmlString("th", "", "center", 3, "評等");
            setHtmlString("th", "", "center", 6, "信用危險<br />/保險金額<br />NTD");
            setHtmlString("th", "", "center", 5, "進口商<br />出險%");

            g_stringBuilder.Append("</tr>");
            g_stringBuilder.Append("</thead>");
            g_stringBuilder.Append("<tbody>");

            foreach (DataRow m_dr in m_summaryOfUnpaidPlanDT.Rows)
            {
                #region 設定成員變數

                m_uid = m_dr["UID"].ToString();

                #endregion

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("td", "rowspan=\"2\"", "center", 2, g_count.ToString());
                setHtmlString("td", "rowspan=\"2\"", "center", 4, m_dr["CASE_MARK"].ToString());
                setHtmlString("td", "", "center", 6, m_dr["EXPORTER_NAME"].ToString());
                setHtmlString("td", "", "center", 9, m_dr["INS_BEG_DATE"].ToString());
                setHtmlString("td", "", "center", 10, m_dr["LOSS_CNT"].ToString());
                setHtmlString("td", "colspan=\"3\"", "center", 15, m_dr["IMPORTER_NAME"].ToString());
                setHtmlString("td", "", "center", 5, m_dr["IMPORTER_NATION"].ToString());
                setHtmlString("td", "rowspan=\"2\"", "center", 4, m_dr["UNPAID_REASON"].ToString());
                setHtmlString("td", "rowspan=\"2\"", "center", 6, m_dr["LAST_MONTH_RISK_AMT"].ToString());
                setHtmlString("td", "rowspan=\"2\"", "center", 6, m_dr["CURR_MONTH_RISK_AMT"].ToString());
                setHtmlString("td", "rowspan=\"2\"", "center", 6, m_dr["CREDIT_RISK_CHG_AMT"].ToString());

                #region 目前狀況

                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;width: 24%;text-align: left;\" rowspan=\"2\">");
                g_stringBuilder.Append("<ul style=\"list-style-type: none; padding: 0px;\">");
                g_stringBuilder.Append("<li><div style=\"height: 0.4rem;width: 0.4rem;background-color: black;border-radius: 50%;display: inline-block;\"></div>交易概述：</li>");
                g_stringBuilder.Append("<li><div style=\"height: 0.4rem;width: 0.4rem;background-color: black;border-radius: 50%;display: inline-block;\"></div>預期通知與損失通知：</li>");
                g_stringBuilder.Append("<li><div style=\"height: 0.4rem;width: 0.4rem;background-color: black;border-radius: 50%;display: inline-block;\"></div>應收帳款狀況：</li>");
                g_stringBuilder.Append("<li><div style=\"height: 0.4rem;width: 0.4rem;background-color: black;border-radius: 50%;display: inline-block;\"></div>追蹤情形：");
                g_stringBuilder.Append("<ul style=\"list-style-type: decimal; padding: 0px 0px 0px 9px;\">");

                #region 查追蹤情形

                //if (g_claimReportBL == null)
                //{
                //    g_claimReportBL = new ClaimReportBL(_userInfo.user, _funcID, _programID, "btnQuery_Click");
                //}

                DataTable m_trackingSituationDT = new DataTable();

                foreach (DataRow m_trackingSituation in m_trackingSituationDT.Rows)
                {
                    g_stringBuilder.Append("<li>" + m_trackingSituation["TRACE_DATE"] + ":" + m_trackingSituation["TRACE_DESC"] + "</li>");
                }

                #endregion

                g_stringBuilder.Append("</ul>");
                g_stringBuilder.Append("</li>");
                g_stringBuilder.Append("</ul>");
                g_stringBuilder.Append("</td>");

                #endregion

                setHtmlString("td", "rowspan=\"2\"", "center", 3, m_dr["WF_BRANCH_ID"].ToString());

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["INSURE_TYPE"] + "</td>");
                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["NOTICE_DATE"] + "</td>");
                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["INS_CNT"] + "</td>");
                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["IMPORT_LIMIT_AMT"] + "</td>");
                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["IMPORT_ASSORT_GRADE"] + "</td>");
                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["INS_CREDIT_RISK_AMT"] + "</td>");
                g_stringBuilder.Append("<td style=\"border: 1px solid black;text-align: center;word-break: break-all;\">" + m_dr["IMPORTER_RISK_PCT"] + "%</td>");

                g_stringBuilder.Append("</tr>");

                g_count += 1;

            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");
            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "1.未付款保案彙總報表.pdf";

            getReport();

        }

        /// <summary>
        /// 未決賠款估算表(半年報)，提供未決賠款統計資料
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void getUnresolvedClaimsEstimateReport()
        {
            //DataTable m_unresolvedClaimsEstimateDT = g_claimReportBL.QueryUnresolvedClaimsEstimateReport();
            DataTable m_unresolvedClaimsEstimateDT = new DataTable();

            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            if (m_unresolvedClaimsEstimateDT.Rows.Count > 0)
            {
                g_stringBuilder.Append("<h6 style=\"margin-bottom: 5px;\">3.未決賠款估算表(半年報)，提供未決賠款統計資料</h6>");
                g_stringBuilder.Append("<div style=\"text-align: center;font-size: 10px;\">" + DateTime.Now.ToString("yyy", m_culture) + "年度上期輸出保險未決賠款案件估計明細表</div>");
                g_stringBuilder.Append("<div style=\"text-align: center;font-size: 10px;\">編表日期：" + DateTime.Now.ToString("yyy年MM月dd日", m_culture) + "</div>");
                g_stringBuilder.Append("<div style=\"text-align: right;font-size: 10px;margin-bottom: 5px;\">單位:新台幣元</div>");
                g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
                g_stringBuilder.Append("<thead>");
                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 10, "經辦單位");
                setHtmlString("th", "", "center", 15, "出口商");
                setHtmlString("th", "", "center", 8, "險別");
                setHtmlString("th", "", "center", 10, "1-6月未決賠款<br />估計數");
                setHtmlString("th", "", "center", 7, "簽單年度");
                setHtmlString("th", "", "center", 5, "自留率<br />(%)");
                setHtmlString("th", "", "center", 10, "自留額");
                setHtmlString("th", "", "center", 10, "582專案補助款");
                setHtmlString("th", "", "center", 10, "調整後自留額");
                setHtmlString("th", "", "center", 15, "備註");

                g_stringBuilder.Append("</tr>");
                g_stringBuilder.Append("</thead>");
                g_stringBuilder.Append("<tbody>");

                foreach (DataRow m_dr in m_unresolvedClaimsEstimateDT.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 8, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 7, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 5, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                g_stringBuilder.Append("</tbody>");
                g_stringBuilder.Append("</table>");
            }

            g_stringBuilder.Append("<br />");
            g_stringBuilder.Append("<br />");

            DataTable m_summaryOfOutstandingClaimsGroupByDeptDT = new DataTable();
            DataTable m_summaryOfOutstandingClaimsGroupByInsureTypeDT = new DataTable();


            if (m_summaryOfOutstandingClaimsGroupByDeptDT.Rows.Count > 0)
            {
                g_stringBuilder.Append("<div style=\"text-align: center;font-size: 10px;margin-bottom: 5px;\">" + DateTime.Now.ToString("yyy", m_culture) + "年度上期輸出保險未決賠款估計彙總表</div>");
                g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
                g_stringBuilder.Append("<thead>");
                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "colspan=\"2\"", "center", 18, "經辦單位");
                setHtmlString("th", "", "center", 15, "險別");
                setHtmlString("th", "", "center", 18, "1-6月未決賠款估計數");
                setHtmlString("th", "", "center", 5, "件數");
                setHtmlString("th", "", "center", 15, "自留額");
                setHtmlString("th", "", "center", 14, "582專案補助款");
                setHtmlString("th", "", "center", 15, "調整後自留額");

                g_stringBuilder.Append("</tr>");
                g_stringBuilder.Append("</thead>");
                g_stringBuilder.Append("<tbody>");

                foreach (DataRow m_dr in m_summaryOfOutstandingClaimsGroupByDeptDT.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "colspan=\"2\"", "center", 18, "");
                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 18, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 5, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 14, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                foreach (DataRow m_dr in m_summaryOfOutstandingClaimsGroupByInsureTypeDT.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 9, "");
                    setHtmlString("td", "", "center", 9, "");
                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 18, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 5, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 14, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                #region 合計

                //金額
                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("td", "rowspan=\"2\" colspan=\"2\"", "center", 18, "合計");
                setHtmlString("td", "", "center", 15, "金額");
                setHtmlString("td", "", "right", 18, "1");
                setHtmlString("td", "", "right", 5, "1");
                setHtmlString("td", "", "right", 15, "1");
                setHtmlString("td", "", "right", 14, "1");
                setHtmlString("td", "", "right", 15, "1");

                g_stringBuilder.Append("</tr>");

                //再保險攤賠金額
                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("td", "", "center", 15, "再保險攤賠金額");
                setHtmlString("td", "", "right", 18, "1");
                setHtmlString("td", "", "center", 5, "適用582專案件數");
                setHtmlString("td", "", "center", 15, "1");
                setHtmlString("td", "", "center", 14, "");
                setHtmlString("td", "", "center", 15, "");

                g_stringBuilder.Append("</tr>");

                #endregion

                g_stringBuilder.Append("</tbody>");
                g_stringBuilder.Append("</table>");
            }


            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "3.未決賠款估算表(半年報)，提供未決賠款統計資料.pdf";

            getReport();
        }

        /// <summary>
        /// 4.	風險彙總(月報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void getSummaryOfRiskReport()
        {
            DataTable m_dt = null;

            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>4.風險彙總(月報)，年度累計逾期金額/當月新增/國家別統計相關資料</h2>");

            #region 逾期可能賠付案件金額表

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy.MM.dd", m_culture) + "止累計逾期可能賠付案件金額表</h3>");
            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 10, "被保險人");
            setHtmlString("th", "", "center", 4, "幣別");
            setHtmlString("th", "colspan=\"3\"", "center", 13, "未付金額/ICL");
            setHtmlString("th", "", "center", 5, "匯率");
            setHtmlString("th", "", "center", 5, "賠償<br />比率");
            setHtmlString("th", "", "center", 15, "可能理賠金額(政治/信用危險：NT$)");
            setHtmlString("th", "", "center", 12, "自留可能理賠金額NT$/年度別");
            setHtmlString("th", "", "center", 6, "險別");
            setHtmlString("th", "", "center", 18, "等級/國別/產品");
            setHtmlString("th", "", "center", 12, "等級/買主");

            g_stringBuilder.Append("</tr>");

            //逾期可能賠付案件金額表資料來源
            m_dt = new DataTable();

            if (m_dt.Rows.Count > 0)
            {
                DataRow m_lastDr = m_dt.AsEnumerable().Last();

                foreach (DataRow m_dr in m_dt.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 4, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "colspan=\"3\"", "right", 13, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "colspan=\"2\"", "center", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 12, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 6, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 18, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 12, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                    if (m_dr.Equals(m_lastDr)) // 最後一筆和某個規則
                    {
                        g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                        setHtmlString("td", "", "center", 10, "");
                        setHtmlString("td", "", "center", 4, "");
                        setHtmlString("td", "colspan=\"3\"", "right", 13, "");
                        setHtmlString("th", "colspan=\"2\"", "center", 10, "小計");
                        setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());
                        setHtmlString("td", "", "right", 12, m_dr["CASE_MARK"].ToString());
                        setHtmlString("td", "", "center", 6, g_count.ToString());
                        setHtmlString("td", "", "center", 18, "");
                        setHtmlString("td", "", "center", 10, "");

                        g_stringBuilder.Append("</tr>");

                        if (m_dr.Equals(m_lastDr))
                        {
                            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                            setHtmlString("th", "colspan=\"7\"", "center", 37, "全部逾期案件--可能整體賠款合計");
                            setHtmlString("td", "", "right", 15, "1");
                            setHtmlString("td", "", "right", 12, m_dr["CASE_MARK"].ToString());
                            setHtmlString("td", "", "center", 6, g_count.ToString());
                            setHtmlString("td", "colspan=\"2\"", "center", 30, "");

                            g_stringBuilder.Append("</tr>");

                            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                            setHtmlString("th", "colspan=\"7\"", "center", 37, "全部逾期案件-再保可能攤賠款合計");
                            setHtmlString("td", "", "right", 15, "1");
                            setHtmlString("td", "", "right", 12, m_dr["CASE_MARK"].ToString());
                            setHtmlString("td", "", "center", 6, g_count.ToString());
                            setHtmlString("td", "colspan=\"2\"", "center", 30, "");

                            g_stringBuilder.Append("</tr>");

                            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                            setHtmlString("th", "colspan=\"7\"", "center", 37, "全部逾期案件-可能自留賠款合計");
                            setHtmlString("td", "", "right", 15, "1");
                            setHtmlString("td", "", "right", 12, m_dr["CASE_MARK"].ToString());
                            setHtmlString("td", "", "center", 6, g_count.ToString());
                            setHtmlString("td", "colspan=\"2\"", "center", 30, "");

                            g_stringBuilder.Append("</tr>");

                            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                            setHtmlString("th", "colspan=\"3\"", "center", 21, "適用582件數/金額/可能補助賠款");
                            setHtmlString("td", "", "center", 3, "");
                            setHtmlString("td", "colspan=\"3\"", "center", 13, "");
                            setHtmlString("td", "", "right", 15, "1");
                            setHtmlString("td", "colspan=\"4\"", "center", 48, "");

                            g_stringBuilder.Append("</tr>");

                            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                            setHtmlString("th", "colspan=\"4\"", "center", 26, "調整後本行可能自留賠款");
                            setHtmlString("td", "colspan=\"4\"", "right", 26, "");
                            setHtmlString("td", "colspan=\"4\"", "center", 48, "");

                            g_stringBuilder.Append("</tr>");

                        }

                        g_count = 0;
                    }

                    g_count += 1;
                }

            }

            else
            {
                setRowNoData(12);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 新增逾期案件

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy.MM.dd", m_culture) + "止累計逾期可能賠付案件金額表</h3>");
            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 15, "被保險人");
            setHtmlString("th", "", "center", 9, "幣別");
            setHtmlString("th", "", "center", 15, "未付金額/ICL");
            setHtmlString("th", "", "center", 15, "匯率");
            setHtmlString("th", "", "center", 15, "賠償<br />比率");
            setHtmlString("th", "", "center", 14, "可能理賠金額(政治/信用危險：NT$)");
            setHtmlString("th", "", "center", 23, "自留可能理賠金額NT$/年度別");

            g_stringBuilder.Append("</tr>");

            //新增逾期案件資料來源
            m_dt = new DataTable();

            if (m_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in m_dt.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 9, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 14, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 23, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "colspan=\"3\"", "center", 15, "合計/件數/金額");
                setHtmlString("td", "", "center", 9, "");
                setHtmlString("td", "", "right", 15, "");
                setHtmlString("td", " colspan=\"2\" rowspan=\"5\"", "center", 15, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("td", "colspan=\"3\" rowspan=\"2\"", "center", 15, "");
                setHtmlString("th", "", "center", 9, "再保險可能攤賠");
                setHtmlString("td", "", "right", 15, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 9, "自留可能賠款");
                setHtmlString("td", "", "right", 15, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "colspan=\"3\"", "center", 15, "新增582件數/金額/可能補助賠款");
                setHtmlString("td", "", "center", 9, "");
                setHtmlString("td", "", "right", 15, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "colspan=\"4\"", "center", 15, "調整後本行可能自留賠款");
                setHtmlString("td", "", "center", 15, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(7);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 累計逾期可能賠付案件金額統計

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy.MM.dd", m_culture) + "止累計逾期可能賠付案件金額統計</h3>");
            g_stringBuilder.Append("<h5 style=\"text-align: right;margin-bottom: 5px;\">幣別:新臺幣元</h5>");
            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 40, "國家別");
            setHtmlString("th", "", "center", 20, "逾期件數");
            setHtmlString("th", "", "center", 40, "逾期可能賠付金額");

            g_stringBuilder.Append("</tr>");

            //累計逾期可能賠付案件金額統計資料來源
            m_dt = new DataTable();

            if (m_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in m_dt.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 40, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 40, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "合計");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "再保險可能攤賠金額");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "本行可能自留賠款");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "582專案可能自留賠款補助");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "調整後本行可能自留賠款");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 新增逾期可能賠付案件金額統計

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy年MM月份", m_culture) + "新增逾期可能賠付案件金額統計</h3>");
            g_stringBuilder.Append("<h5 style=\"text-align: right;margin-bottom: 5px;\">幣別:新臺幣元</h5>");
            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 40, "國家別");
            setHtmlString("th", "", "center", 20, "逾期件數");
            setHtmlString("th", "", "center", 40, "逾期可能賠付金額");

            g_stringBuilder.Append("</tr>");

            //新增逾期可能賠付案件金額統計資料來源
            m_dt = new DataTable();

            if (m_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in m_dt.Rows)
                {
                    #region 設定成員變數


                    #endregion

                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 40, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 40, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "合計");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "再保險可能攤賠金額");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 40, "本行可能自留賠款");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "right", 40, "");

                g_stringBuilder.Append("</tr>");

            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "4.風險彙總(月報).pdf";

            getReport();
        }

        /// <summary>
        /// 5.	賠款明細表(月報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void getIndemnityScheduleReport()
        {
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>5.賠款明細表(月報)，賠款/收回明細資料。多次收回即顯示多筆</h2>");

            #region 輸出保險賠款明細表

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy年", m_culture) + "1-12月輸出保險賠款明細表</h3>");

            #region 設定成員變數

            //逾期可能賠付案件金額表資料來源
            g_dt = new DataTable();
            //m_dt = new DataTable();

            //一張表資料筆數2筆
            g_oneTableDataCount = 2;

            g_selectDt = new DataTable();

            //column靠左靠右......
            g_cellStyleList = new List<string>()
                {
                    "center",
                    "center",
                    "right"
                };

            g_titleList = new List<CodeName>()
                {
                    new CodeName("EXPORTER_NAME", "被保險人"),
                    new CodeName("EXPORTER_NAME", "案號"),
                    new CodeName("EXPORTER_NAME", "保險單號碼/保險證明書號碼"),
                    new CodeName("EXPORTER_NAME", "輸出貨價"),
                    new CodeName("EXPORTER_NAME", "被保險人信用配額或開狀銀行信用配額<br />(美元/新臺幣元)"),
                    new CodeName("EXPORTER_NAME", "買主/開狀銀行"),
                    new CodeName("EXPORTER_NAME", "買主國家/地區"),
                    new CodeName("EXPORTER_NAME", "交易產品"),
                    new CodeName("EXPORTER_NAME", "買主信用等級"),
                    new CodeName("EXPORTER_NAME", "賠付日期"),
                    new CodeName("EXPORTER_NAME", "賠付金額<br />(新臺幣元)"),
                    new CodeName("EXPORTER_NAME", "賠付原因"),
                    new CodeName("EXPORTER_NAME", "簽單年度"),
                    new CodeName("EXPORTER_NAME", "再保險攤賠比率(%)"),
                    new CodeName("EXPORTER_NAME", "再保險攤賠<br />(新臺幣元)"),
                    new CodeName("EXPORTER_NAME", "本行自留賠款<br />(新臺幣元)"),
                    new CodeName("EXPORTER_NAME", "適用582專案金額<br />(新臺幣元）"),
                    new CodeName("EXPORTER_NAME", "適用加強輸出保險準備計劃<br />(新臺幣元）"),
                    new CodeName("EXPORTER_NAME", "調整後本行自留賠款<br />(新臺幣元）"),
                    new CodeName("EXPORTER_NAME", "經辦單位")
                };

            //第一列標頭寬度
            g_titleWidth = 28;

            #endregion

            genColHtml();

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "5.賠款明細表(月報).pdf";

            getReport();
        }

        private void getReport6()
        {
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>6.理賠前收回明細表(月報)，賠款/款項已全部收回之逾期案件資料</h2>");

            #region 輸出保險理賠前收回明細表

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy年MM月", m_culture) + "輸出保險理賠前收回明細表</h3>");

            #region 設定成員變數

            //輸出保險理賠前收回明細表來源
            //g_dt = g_claimReportBL.QuerySummaryOfUnpaidPlan(txtMonth.Text.Trim());
            g_dt = new DataTable();

            //一張表資料筆數2筆
            g_oneTableDataCount = 3;

            g_cellStyleList = new List<string>()
                {
                    "center",
                    "center",
                    "center",
                    "center"
                };

            g_titleList = new List<CodeName>()
                {
                    new CodeName("EXPORTER_NAME", "被保險人"),
                    new CodeName("EXPORTER_NAME", "險別"),
                    new CodeName("EXPORTER_NAME", "輸出貨價<br />（US$）"),
                    new CodeName("EXPORTER_NAME", "輸出貨價"),
                    new CodeName("EXPORTER_NAME", "輸出地區"),
                    new CodeName("EXPORTER_NAME", "輸出產品"),
                    new CodeName("EXPORTER_NAME", "收回日期"),
                    new CodeName("EXPORTER_NAME", "信用保險金額<br />(新臺幣千元)"),
                    new CodeName("EXPORTER_NAME", "未付原因"),
                    new CodeName("EXPORTER_NAME", "經辦單位"),
                    new CodeName("EXPORTER_NAME", "處理人員")
                };

            //第一列標頭寬度
            g_titleWidth = 22;

            #endregion

            genColHtml();

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "6.理賠前收回明細表(月報).pdf";

            getReport();
        }

        private void getReport7()
        {
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>7.理賠後收回明細表(月報)，賠付後收回之案件資料</h2>");

            #region 輸出保險理賠後收回款明細表

            g_stringBuilder.Append("<h3 style=\"text-align: center;\">" + DateTime.Now.ToString("yyy年", m_culture) + "1-12月輸出保險理賠後收回款明細表</h3>");

            #region 設定成員變數

            //輸出保險理賠後收回款明細表來源
            //g_dt = g_claimReportBL.QuerySummaryOfUnpaidPlan(txtMonth.Text.Trim());
            g_dt = new DataTable();

            //一張表資料筆數2筆
            g_oneTableDataCount = 3;

            g_selectDt = new DataTable();

            g_cellStyleList = new List<string>()
                {
                    "center",
                    "center",
                    "center",
                    "center"
                };

            g_titleList = new List<CodeName>()
                {
                   new CodeName("EXPORTER_NAME","被保險人") ,
                   new CodeName("EXPORTER_NAME","險別") ,
                   new CodeName("EXPORTER_NAME","輸出地區") ,
                   new CodeName("EXPORTER_NAME","交易產品") ,
                   new CodeName("EXPORTER_NAME","國外買主/開狀銀行") ,
                   new CodeName("EXPORTER_NAME","被保險人信用配額或開狀銀行信用配額<br />(美元/新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","賠付日期") ,
                   new CodeName("EXPORTER_NAME","賠付金額<br />(新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","賠付原因") ,
                   new CodeName("EXPORTER_NAME","收回日期") ,
                   new CodeName("EXPORTER_NAME","收回款<br />(新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","本行分得收回款金額<br />(新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","簽單年度") ,
                   new CodeName("EXPORTER_NAME","再保險攤賠比率(%)") ,
                   new CodeName("EXPORTER_NAME","分配予再保險公司之金額<br />(新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","自留理賠後收回款<br />(新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","分配予582專案補助之金額<br />(新臺幣元)") ,
                   new CodeName("EXPORTER_NAME","追索情形")
                };

            //第一列標頭寬度
            g_titleWidth = 22;

            #endregion

            genColHtml();

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "7.理賠後收回明細表(月報).pdf";

            getReport();
        }

        /// <summary>
        /// 8.追債費用表(月報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void report8()
        {
            DataTable m_dt = null;

            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>8.追債費用表(月報)</h2>");

            #region 追債費用表

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "left", 15, "追債費用＝");
            setHtmlString("th", "", "right", 10, "");
            setHtmlString("th", "colspan=\"3\"", "center", 2, "-");
            setHtmlString("th", "", "right", 10, "");
            setHtmlString("th", "", "center", 2, "=");
            setHtmlString("th", "", "right", 10, "");

            g_stringBuilder.Append("</tr>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "left", 15, "自留追債費用＝");
            setHtmlString("th", "", "right", 10, "");
            setHtmlString("th", "colspan=\"3\"", "center", 2, "-");
            setHtmlString("th", "", "right", 10, "");
            setHtmlString("th", "", "center", 2, "=");
            setHtmlString("th", "", "right", 10, "");

            g_stringBuilder.Append("</tr>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");
            g_stringBuilder.Append("</tr>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "colspan=\"4\"", "center", 37, "追債費用支出");
            setHtmlString("th", "", "right", 2, "");
            setHtmlString("th", "", "center", 10, "再保分攤");
            setHtmlString("th", "", "center", 10, "本行分攤");
            setHtmlString("th", "", "center", 31, "");

            g_stringBuilder.Append("</tr>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 15, "日期");
            setHtmlString("th", "", "center", 10, "金額");
            setHtmlString("th", "", "center", 2, "");
            setHtmlString("th", "", "center", 10, "減項");
            setHtmlString("th", "", "center", 2, "");
            setHtmlString("th", "", "center", 10, "金額");
            setHtmlString("th", "", "center", 10, "金額");
            setHtmlString("th", "", "center", 31, "備註");
            setHtmlString("th", "", "center", 10, "經辦單位");

            g_stringBuilder.Append("</tr>");

            //追債費用表資料來源
            m_dt = new DataTable();

            if (m_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in m_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 2, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 2, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "right", 10, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 31, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 10, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");

                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("td", "", "center", 15, "");
                setHtmlString("td", "", "right", 10, "");
                setHtmlString("td", "", "center", 2, "");
                setHtmlString("td", "", "center", 10, "");
                setHtmlString("td", "", "center", 2, "");
                setHtmlString("td", "", "right", 10, "");
                setHtmlString("td", "", "right", 10, "0");
                setHtmlString("td", "", "center", 31, "");
                setHtmlString("td", "", "center", 10, "");

                g_stringBuilder.Append("</tr>");

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("td", "", "center", 15, "");
                setHtmlString("td", "", "right", 10, "");
                setHtmlString("td", "", "center", 2, "");
                setHtmlString("td", "", "center", 10, "");
                setHtmlString("td", "", "center", 2, "");
                setHtmlString("td", "", "right", 10, "");
                setHtmlString("td", "", "right", 10, "");
                setHtmlString("td", "", "center", 31, "");
                setHtmlString("td", "", "center", 10, "");

                g_stringBuilder.Append("</tr>");

            }
            else
            {
                setRowNoData(9);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "8.追債費用表(月報).pdf";

            getReport();
        }

        /// <summary>
        /// 9.賠款分析表(月報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void report9()
        {
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>9.賠款分析表(月報)，提供依險別/單位別/國家別/交易產品別之統計資料</h2>");

            g_stringBuilder.Append("<h3>" + DateTime.Now.ToString("yyy年", m_culture) + "1-12月本行輸出保險賠款分析表(險別)</h3>");

            #region 本行輸出保險賠款分析表(單位別)

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 25, "出口商");
            setHtmlString("th", "", "center", 12, "險別");
            setHtmlString("th", "", "center", 17, "輸出產品");
            setHtmlString("th", "", "center", 17, "賠付金額<br />(新臺幣元)");
            setHtmlString("th", "", "center", 17, "小計<br />(新臺幣元)");
            setHtmlString("th", "", "center", 12, "百分比");

            g_stringBuilder.Append("</tr>");

            //本行輸出保險賠款分析表(單位別)資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 25, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 12, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 17, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 17, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 17, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 12, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 25, "合計");
                setHtmlString("td", "", "center", 12, "");
                setHtmlString("td", "", "center", 17, "");
                setHtmlString("td", "", "center", 17, "");
                setHtmlString("td", "", "center", 17, "");
                setHtmlString("td", "", "center", 12, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(6);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 本行輸出保險賠款分析表(國家別)

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 30, "出口商");
            setHtmlString("th", "", "center", 15, "國家別");
            setHtmlString("th", "", "center", 20, "賠付金額<br />(新臺幣元)");
            setHtmlString("th", "", "center", 20, "小計<br />(新臺幣元)");
            setHtmlString("th", "", "center", 15, "百分比");

            g_stringBuilder.Append("</tr>");

            //本行輸出保險賠款分析表(國家別)資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("th", "", "center", 30, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 15, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 30, "合計");
                setHtmlString("td", "", "center", 15, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 15, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(5);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 本行輸出保險賠款分析表(交易產品別)

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 30, "出口商");
            setHtmlString("th", "", "center", 15, "交易產品");
            setHtmlString("th", "", "center", 20, "賠付金額<br />(新臺幣元)");
            setHtmlString("th", "", "center", 20, "小計<br />(新臺幣元)");
            setHtmlString("th", "", "center", 15, "百分比");

            g_stringBuilder.Append("</tr>");

            //本行輸出保險賠款分析表(交易產品別)資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("th", "", "center", 30, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 15, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 15, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 30, "合計");
                setHtmlString("td", "", "center", 15, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 15, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(5);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "9.賠款分析表(月報).pdf";

            getReport();
        }

        /// <summary>
        /// 10.理賠後收回款分析表(月報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void report10()
        {
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>10.理賠後收回款分析表(月報)，提供理賠後收回款金額之彙統計表報表</ h2>");

            g_stringBuilder.Append("<h3>" + DateTime.Now.ToString("yyy年", m_culture) + "1-3月輸出保險自留理賠後收回款分析表</h3>");

            g_stringBuilder.Append("<h5 style=\"text - align: right; margin - bottom: 5px;\">單位:新臺幣元</h5>");

            #region 承保單位別

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 35, "承保單位別");
            setHtmlString("th", "", "center", 40, "自留理賠後收回款金額");
            setHtmlString("th", "", "center", 25, "百分比");

            g_stringBuilder.Append("</tr>");

            //承保單位別資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 35, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 40, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 25, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 35, "合計");
                setHtmlString("td", "", "center", 40, "");
                setHtmlString("td", "", "center", 25, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 險別

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 35, "險別");
            setHtmlString("th", "", "center", 40, "自留理賠後收回款金額");
            setHtmlString("th", "", "center", 25, "百分比");

            g_stringBuilder.Append("</tr>");

            //險別資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 35, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 40, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 25, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 35, "合計");
                setHtmlString("td", "", "center", 40, "");
                setHtmlString("td", "", "center", 25, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 承保國家別

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 35, "承保國家別");
            setHtmlString("th", "", "center", 40, "自留理賠後收回款金額");
            setHtmlString("th", "", "center", 25, "百分比");


            g_stringBuilder.Append("</tr>");

            //承保國家別資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("th", "", "center", 35, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 40, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 25, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 30, "合計");
                setHtmlString("td", "", "center", 40, "");
                setHtmlString("td", "", "center", 25, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            #region 交易貨品別

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 35, "交易貨品別");
            setHtmlString("th", "", "center", 40, "自留理賠後收回款金額");
            setHtmlString("th", "", "center", 25, "百分比");


            g_stringBuilder.Append("</tr>");

            //交易貨品別資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("th", "", "center", 35, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 40, m_dr["CASE_MARK"].ToString());
                    setHtmlString("th", "", "center", 25, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 30, "合計");
                setHtmlString("td", "", "center", 40, "");
                setHtmlString("td", "", "center", 25, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "10.理賠後收回款分析表(月報).pdf";

            getReport();
        }

        /// <summary>
        /// 11.提存前損失率報表(月/季報)
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void report11()
        {
            g_fullName = string.Empty;
            g_stringBuilder.Length = 0;
            g_count = 1;

            CultureInfo m_culture = new CultureInfo("zh-TW");
            m_culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            g_stringBuilder.Append("<div style=\"size: A4;margin: 0 auto;width: 820px;\">");

            g_stringBuilder.Append("<h2>11.提存前損失率報表(月/季報)</ h2>");

            g_stringBuilder.Append("<h3>" + DateTime.Now.ToString("yyy年", m_culture) + "度輸出保險業務損失率(以未提存準備計算)</ h3>");

            g_stringBuilder.Append("<h5 style=\"text - align: right; margin - bottom: 5px;\">單位：％</h5>");

            #region 損失率及淨損失率

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "rowspan=\"2\"", "center", 20, "104年度/月份");
            setHtmlString("th", "colspan=\"2\"", "center", 40, "整體業務");
            setHtmlString("th", "colspan=\"2\"", "center", 40, "自留業務");

            g_stringBuilder.Append("</tr>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 20, "損失率");
            setHtmlString("th", "", "center", 20, "淨損失率");
            setHtmlString("th", "", "center", 20, "損失率");
            setHtmlString("th", "", "center", 20, "淨損失率");

            g_stringBuilder.Append("</tr>");

            //損失率及淨損失率資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());


                    g_stringBuilder.Append("</tr>");
                }
            }
            else
            {
                setRowNoData(3);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion

            g_stringBuilder.Append("<br />");

            g_stringBuilder.Append("<p><span>註一：104年度截至12月份損失率及淨損失率計算如下</span><span style=\"float: right\">(單位:新臺幣元)</span></p>");
            g_stringBuilder.Append("<p>（一）整體業務損失率＝賠款支出／保險費收入</p>");
            g_stringBuilder.Append("<p style=\"margin - left: 10rem\">＝78,887,860／305,508,535＝25.82%</p>");
            g_stringBuilder.Append("<p>（二）自留業務損失率＝自留賠款支出／自留保費收入</p>");
            g_stringBuilder.Append("<p style=\"margin - left: 10rem\">＝49,584,436／171,360,863＝28.94%</p>");
            g_stringBuilder.Append("<p>（三）整體業務淨損失率＝（賠款支出－收回款＋追債費用）／保費收入</p> ");
            g_stringBuilder.Append("<p style=\"margin - left: 10rem\">＝（78,887,860－27,447,334＋68,366)／305,508,535＝16.86%</p>");
            g_stringBuilder.Append("<p>（四）自留業務淨損失率＝（自留賠款支出－自留收回款＋自留追債費用）／自留保費收入</p>");
            g_stringBuilder.Append("<p style=\"margin - left: 10rem\">＝（49,584,436－23,436,622＋34,183）／171,360,863=15.28%</p>");
            g_stringBuilder.Append("<p>註二：經查世界前三大輸出信用機構公布於官網最新之損失率情形，104年第三季Coface淨損失率為52.5 %，Euler Hermes淨損失率為57.3 %，Atradius僅公布103年度損失率為50.4 %，未公布104年第三季損失率。前述三大機構皆未公布104年度第四季數據。</ p > ");
            g_stringBuilder.Append("<p>註三：承保單位別損失率(每季出現)</p>");

            #region 承保單位別損失率

            g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: auto;width: 100%;\">");
            g_stringBuilder.Append("<tbody>");

            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", "center", 20, "106年度/季");
            setHtmlString("th", "", "center", 20, "單位");
            setHtmlString("th", "", "center", 20, "整體業務賠款");
            setHtmlString("th", "", "center", 20, "保費收入");
            setHtmlString("th", "", "center", 20, "損失率");

            g_stringBuilder.Append("</tr>");

            //承保單位別損失率資料來源
            g_dt = new DataTable();

            if (g_dt.Rows.Count > 0)
            {
                foreach (DataRow m_dr in g_dt.Rows)
                {
                    g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());
                    setHtmlString("td", "", "center", 20, m_dr["CASE_MARK"].ToString());

                    g_stringBuilder.Append("</tr>");
                }

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", 20, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 20, "");
                setHtmlString("td", "", "center", 20, "");

                g_stringBuilder.Append("</tr>");
            }
            else
            {
                setRowNoData(5);
            }

            g_stringBuilder.Append("</tbody>");
            g_stringBuilder.Append("</table>");

            #endregion
            
            g_stringBuilder.Append("</div>");

            //完整路徑名稱
            g_fullName = g_path + "//" + "11.提存前損失率報表(月/季報).pdf";

            getReport();
        }

        /// <summary>
        /// 產生pdf
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void getReport()
        {
            //g_rptBytes = PdfLib.HtmlStrToPdf(g_stringBuilder.ToString(), "", true);

            //File.WriteAllBytes(g_fullName, g_rptBytes);
        }

        /// <summary>
        /// 設定HTML(td)or(th)字串
        /// </summary>
        /// <param name="p_tdORth">(td)or(th)</param>
        /// <param name="p_otherAttributes">其他屬性</param>
        /// <param name="p_textAlign">欄位資料擺放位置</param>
        /// <param name="p_widthStyle">欄位寬度</param>
        /// <param name="p_value">欄位值</param>
        /// <remarks></remarks>
        private void setHtmlString(string p_tdORth, string p_otherAttributes, string p_textAlign, int p_widthStyle, string p_value)
        {
            string m_tdORth = p_tdORth.Trim();
            string m_organizeOtherAttributes = string.IsNullOrEmpty(p_otherAttributes.Trim()) ? "" : " " + p_otherAttributes.Trim();
            string m_organizeTextAlign = p_textAlign.Trim();
            string m_organizeWidthStyle = p_widthStyle.ToString();

            g_stringBuilder.Append(string.Format("<{0}{1} style=\"border: 1px solid black;text-align: {2};word-break: break-word;width: {3}%;\">{4}</{0}>", m_tdORth, m_organizeOtherAttributes, m_organizeTextAlign, m_organizeWidthStyle, p_value));
        }

        /// <summary>
        /// 設定行無資料
        /// </summary>
        /// <param name="p_colspanNumber">colspan值</param>
        /// <remarks></remarks>
        private void setRowNoData(int p_colspanNumber)
        {
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");
            g_stringBuilder.Append("<td colspan=\"" + p_colspanNumber + "\">查無資料</td>");
            g_stringBuilder.Append("</tr>");
        }

        /// <summary>
        /// 設定列無資料
        /// </summary>
        /// <param name="p_dataName">列資料</param>
        /// <param name="p_titleName">首列名稱</param>
        /// <remarks></remarks>
        private void setColumnHtml(string p_dataName, string p_titleName)
        {
            //均分資料欄位寬度
            int m_dataWidth = (100 - g_titleWidth) / g_oneTableDataCount;
            string m_cellStyle = string.Empty;

            //不滿g_oneTableDataCount，補空白列
            if (g_selectDt.Rows.Count != g_oneTableDataCount)
            {
                for (int i = 0; i < g_oneTableDataCount - g_selectDt.Rows.Count; i++)
                {
                    DataRow m_dr = g_selectDt.NewRow();
                    g_selectDt.Rows.Add(m_dr);
                }
            }

            //第一列
            g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

            setHtmlString("th", "", g_cellStyleList[0], g_titleWidth, p_titleName);
            g_count = 1;

            foreach (DataRow m_dr in g_selectDt.Rows)
            {
                setHtmlString("td", "", g_cellStyleList[g_count], m_dataWidth, m_dr[p_dataName].ToString());
                g_count += 1;
            }

            g_stringBuilder.Append("</tr>");

        }

        /// <summary>
        /// 設定列無資料
        /// </summary>
        /// <param name="p_colspanNumber">colspan值</param>
        /// <param name="p_titleList">所有首列名稱</param>
        /// <remarks></remarks>
        private void setColNoData(int p_colspanNumber, List<CodeName> p_titleList)
        {
            //均分資料欄位寬度
            int m_dataWidth = 100 - g_titleWidth;
            string m_cellStyle = string.Empty;
            string m_otherAttributes = string.Empty;

            g_count = 1;
            foreach (var m_title in p_titleList)
            {

                g_stringBuilder.Append("<tr style=\"height: " + g_rowHeight + "\">");

                setHtmlString("th", "", "center", g_titleWidth, m_title.Name);
                if (g_count == 1)
                {
                    m_otherAttributes = string.Format("colspan=\"{0}\" rowspan=\"{1}\"", p_colspanNumber, p_titleList.Count);
                    setHtmlString("td", m_otherAttributes, "center", m_dataWidth, "查無資料");
                }

                g_stringBuilder.Append("</tr>");

                g_count += 1;

            }

        }

        /// <summary>
        /// 組直式資料Html
        /// </summary>
        /// <param name=""></param>
        /// <remarks></remarks>
        private void genColHtml()
        {
            if (g_dt.Rows.Count > 0)
            {
                //餘數
                int m_remainder = g_dt.Rows.Count % g_oneTableDataCount;
                //共幾張表
                int m_tableCount = m_remainder == 0 ? (g_dt.Rows.Count / g_oneTableDataCount) : (g_dt.Rows.Count / g_oneTableDataCount + 1);

                g_selectDt = new DataTable();

                for (int i = 0; i < m_tableCount; i++)
                {
                    g_selectDt = new DataTable();
                    g_selectDt = g_dt.AsEnumerable().Skip(i * g_oneTableDataCount).Take(g_oneTableDataCount).CopyToDataTable();

                    g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
                    g_stringBuilder.Append("<tbody>");

                    foreach (var m_title in g_titleList)
                    {
                        setColumnHtml(m_title.ID, m_title.Name);
                    }

                    g_stringBuilder.Append("</tbody>");
                    g_stringBuilder.Append("</table>");

                    g_stringBuilder.Append("<br />");

                }
            }
            else
            {
                g_stringBuilder.Append("<table style=\"border: 1px solid black;text-align: center;border-collapse: collapse;font-size: " + g_tableFontSize + ";table-layout: fixed;width: 100%;\">");
                g_stringBuilder.Append("<tbody>");

                setColNoData(g_oneTableDataCount, g_titleList);

                g_stringBuilder.Append("</tbody>");
                g_stringBuilder.Append("</table>");
            }
        }


        #endregion Private Methods
    }
}