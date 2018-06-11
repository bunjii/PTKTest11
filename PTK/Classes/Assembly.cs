﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTK
{
    public class Assembly
    {
        #region fields
        private List<Node> nodes;
        private List<PTK_Element> elems;
        private List<PTK_Material> mats;
        private List<Section> secs;
        private List<PTK_Support> sups;
        #endregion

        #region constructors
        public Assembly(List<Node> _nodes, List<PTK_Element> _elems, List<PTK_Material> _mats,
            List<Section> _secs, List<PTK_Support> _sups)
        {
            nodes = _nodes;
            elems = _elems;
            mats = _mats;
            secs = _secs;
            sups = _sups;
        }
        #endregion

        #region properties
        public List<Node> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }
        public List<PTK_Element> Elems
        {
            get { return elems; }
            set { elems = value; }
        }
        public List<PTK_Material> Mats
        {
            get { return mats; }
            set { mats = value; }
        }
        public List<Section> Secs
        {
            get { return secs; }
            set { secs = value; }
        }
        public List<PTK_Support> Sups
        {
            get { return sups; }
            set { sups = value; }
        }
        #endregion

        #region methods
        #endregion

    }
}
