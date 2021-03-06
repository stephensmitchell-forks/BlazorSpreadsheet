﻿using BlazorSpreadsheetComponent.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent
{
    public class CompCell: ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BCell bcell { get; set; }



        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            int k = -1;
            builder.OpenElement(k++, "td");

            builder.AddAttribute(k++, "style", bcell.GetStyle());

            builder.AddAttribute(k++, "onclick", Clicked);
            builder.AddContent(k++, bcell.Value);
            builder.CloseElement();


            base.BuildRenderTree(builder);
        }


        public void Clicked(UIMouseEventArgs e)
        {

            CompTable a = parent as CompTable;

            CompBlazorSpreadsheet b = a.parent as CompBlazorSpreadsheet;

            b.SelectionChange(bcell.ID);
        }


        public void Dispose()
        {

        }
    }
}
