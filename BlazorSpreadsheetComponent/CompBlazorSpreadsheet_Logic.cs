using BlazorSpreadsheetComponent.BussinesLayer;
using BlazorSpreadsheetComponent.Classes;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent
{
    public class CompBlazorSpreadsheet_Logic : BlazorComponent
    {
        public string Curr_Value = string.Empty;
        public string Curr_Value_old = string.Empty;


        public string Curr_Address= string.Empty;

        public BTable Current_BTable=new BTable();


        protected override void OnInit()
        {
            Current_BTable.Initialize();

            SelectionChange(Current_BTable.Table_List.FirstOrDefault().ID);

            base.OnInit();
        }


        public void SelectionChange(int Par_CellId)
        {


             Current_BTable.ActiveCell = Current_BTable.Table_List.Single(x => x.ID == Par_CellId);
            if (string.IsNullOrEmpty(Current_BTable.ActiveCell.Formula))
            {
                Curr_Value = Current_BTable.ActiveCell.Value;
            }
            else
            {
                Curr_Value = Current_BTable.ActiveCell.Formula.Replace("$!?",null).Replace("?!$", null);
            }


            Curr_Value_old = Curr_Value;

            Curr_Address = Current_BTable.ActiveCell.Address;
            Current_BTable.SelectActiveCell();

            StateHasChanged();
        }




        


       


        public void Cmd_Update()
        {


            if (Curr_Value.Substring(0, 1) == "=")
            {
                

                string a = MyFunctions.MarkReferencedCells(Curr_Value.ToUpper());
                if (!Current_BTable.CheckFormulaForCircuitReference(a, Current_BTable.ActiveCell.Address))
                {
                    Current_BTable.ActiveCell.Formula = a;
                    Current_BTable.Calculate();
                    Curr_Value_old = Curr_Value;

                    Current_BTable.Cmd_Select_Referenced_Cells();

                }
                else
                {
                    
                    JsInterop.Alert("Detected circuit reference!");
                    Curr_Value = Curr_Value_old;
                }
            }
            else
            {
                Current_BTable.ActiveCell.Value = Curr_Value;
            }

            

            StateHasChanged();
        }


        public void Cmd_Select_Referenced_Cells()
        {
            Current_BTable.Cmd_Select_Referenced_Cells();
        }

            public void Dispose()
        {

        }

    }
}
