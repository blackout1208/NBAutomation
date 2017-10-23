using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace NBautoFramework.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class HtmlTableHelper
    {
        private static List<TableDataCollection> _TableDataCollections;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public static void ReadTable(IWebElement table)
        {
            _TableDataCollections = new List<TableDataCollection>();

            var columns = table.FindElement(By.ClassName("rgHeaderWrapper")).FindElements(By.TagName("a"));

            var rows = table.FindElement(By.ClassName("rgDataDiv")).FindElements(By.TagName("tr"));

            var rowIndex = 0;
            foreach (var row in rows)
            {
                var colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));

                if (colDatas.Count != 0)
                {
                    foreach (var colValue in colDatas)
                    {
                        _TableDataCollections.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns.ElementAt(colIndex).Text,
                            ColumnValue = colValue.Text,
                            ColumnSpeciaValues = GetControl(colValue)
                        });
                        colIndex++;
                    }
                }

                rowIndex++;
            }
        }

        private static ColumnSpeciaValues GetControl(IWebElement columnValue)
        {
            ColumnSpeciaValues columnSpecialValue = null;
            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpeciaValues
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = ControlType.HyperLink
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpeciaValues
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = ControlType.Input
                };
            }
            return columnSpecialValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="refColumnName"></param>
        /// <param name="refColumnValue"></param>
        /// <param name="controlToOperate"></param>
        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = _TableDataCollections.Where(o => o.ColumnName.Equals(columnIndex) && o.RowNumber == rowNumber)
                    .Select(o => o.ColumnSpeciaValues).SingleOrDefault();

                //Need to operate on those controls
                if (cell != null)
                {
                    //Since based on the control type, the retriving of text changes
                    //created this kind of control
                    if (cell.ControlType == ControlType.HyperLink)
                    {
                        var returnedControl = cell.ElementCollection.SingleOrDefault(o => o.Text.Equals(controlToOperate));
                        //TODO: Apenas suporta clicks, no futuro temos que tratar de
                        // retornar valores, ou escrever texto...whatever
                        returnedControl?.Click();
                    }
                    if (cell.ControlType == ControlType.Input)
                    {
                        var returnedControl = cell.ElementCollection.SingleOrDefault(o => o.GetAttribute("value").Equals(controlToOperate));
                        returnedControl?.Click();
                    }
                    else
                    {
                        cell.ElementCollection?.First().Click();
                    }
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            foreach (var table in _TableDataCollections)
            {
                if (table.ColumnName.Equals(columnName))
                {
                    if (table.ColumnValue == columnValue)
                    {
                        yield return table.RowNumber;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TableDataCollection
    {
        /// <summary>
        /// 
        /// </summary>
        public int RowNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ColumnValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ColumnSpeciaValues ColumnSpeciaValues { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ColumnSpeciaValues
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ControlType ControlType { get; set; }
    }

    /// <summary>
    /// Type of controls in html
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// 
        /// </summary>
        HyperLink,
        /// <summary>
        /// 
        /// </summary>
        Input
    }
}
