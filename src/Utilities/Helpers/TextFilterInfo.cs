#region Copyright
//=======================================================================================
// Microsoft Azure Customer Advisory Team 
//
// This sample is supplemental to the technical guidance published on my personal
// blog at http://blogs.msdn.com/b/paolos/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE 
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT 
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE 
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY 
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING 
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================
#endregion

#region Using Directives

using System;

#endregion

namespace ServiceBusExplorer.Utilities.Helpers
{
    public class TextFilterInfo
    {
        #region Private Fields
        private string property;
        private string @operator;
        private string filter;
        #endregion

        #region Public Events
        public static event Action OnChange;
        #endregion

        #region Public Constructors
        public TextFilterInfo()
        {
            Property = null;
            Operator = null;
            Value = null;
        }
        #endregion

        #region Public Instance Properties
        public string Property 
        { 
            get
            {
                return property;
            }
            set
            {
                property = Adjust(value);
                OnChange?.Invoke();
            }
        }
        public string Operator
        {
            get
            {
                return @operator;
            }
            set
            {
                @operator = Adjust(value);
                OnChange?.Invoke();
            }
        }

        public string Value
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                OnChange?.Invoke();
            }
        }
        #endregion

        #region Private Methods
        private string Adjust(string word)
        {
            if (String.Compare(word, "Rule Filter", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return "AccessedAt";
            }
            if (String.Compare(word, "Equals", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return "Equals";
            }
            if (String.Compare(word, "Contains", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return "Contains";
            }
            return word;
        }
        #endregion
    }
}
