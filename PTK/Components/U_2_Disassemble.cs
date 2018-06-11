﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using Karamba;

namespace PTK
{
    public class PTK_U_2_Disassemble : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PTK_Util_2_Disassemble class.
        /// </summary>
        public PTK_U_2_Disassemble()
          : base("Disassemble (PTK)", "Disassemble",
              "Disassemble PTK Assemble Model",
              CommonProps.category, CommonProps.subcat5)
        {
            Message = CommonProps.initialMessage;
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("PTK Assembly", "A (PTK)", "PTK Assembly", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("PTK NODE", "N (PTK)", "PTK NODE", GH_ParamAccess.item);
            pManager.AddGenericParameter("PTK ELEM", "E (PTK)", "PTK ELEM", GH_ParamAccess.item);
            pManager.AddGenericParameter("PTK MAT", "M (PTK)", "PTK MAT", GH_ParamAccess.item);
            pManager.AddGenericParameter("PTK SEC", "S (PTK)", "PTK SEC", GH_ParamAccess.item);
            pManager.AddGenericParameter("PTK SUP", "Su (PTK)", "PTK SUP", GH_ParamAccess.item);
            
            pManager.RegisterParam(new Karamba.Supports.Param_Support(), "Krmb SUP", "Su (KARAMBA)", "Karamba SUP");
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            #region variables
            GH_ObjectWrapper wrapAssembly = new GH_ObjectWrapper();
            Assembly assemble;
            List<Node> nodes = new List<Node>();
            List<PTK_Element> elems = new List<PTK_Element>();
            List<PTK_Material> mats = new List<PTK_Material>();
            List<Section> secs = new List<Section>();
            List<PTK_Support> sups = new List<PTK_Support>();
            #endregion

            #region input
            if (!DA.GetData(0, ref wrapAssembly)) { return; }
            wrapAssembly.CastTo<Assembly>(out assemble);
            #endregion

            #region solve
            nodes = assemble.Nodes;
            elems = assemble.Elems;
            mats = assemble.Mats;
            secs = assemble.Secs;
            sups = assemble.Sups;


            List<Karamba.Supports.GH_Support> sups_krmb = new List<Karamba.Supports.GH_Support>();

            foreach (PTK_Support s in sups)
            {
                var tmp_sup = s.Krmb_GH_support;
                
                sups_krmb.Add( tmp_sup );
            }


            #endregion

            #region output
            DA.SetData(0, nodes);
            DA.SetData(1, elems);
            DA.SetData(2, mats);
            DA.SetData(3, secs);
            DA.SetData(4, sups);
            #endregion
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return PTK.Properties.Resources.ico_disassemble;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("807ac401-b08a-4702-8328-84b152af5724"); }
        }
    }
}