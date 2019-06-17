﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.IO;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Contentment.DataEditors
{
    public class CheckboxListConfigurationEditor : ConfigurationEditor
    {
        public const string Items = "items";

        public CheckboxListConfigurationEditor()
            : base()
        {
            var listFields = new[]
            {
                new ConfigurationField
                {
                    Key = "name",
                    Name = "Name",
                    View = "textbox"
                },
                new ConfigurationField
                {
                    Key = "value",
                    Name = "Value",
                    View = "textbox"
                }
            };

            Fields.Add(
                Items,
                "Options",
                "Configure the option items for the checkbox list.",
                IOHelper.ResolveUrl(DataTableDataEditor.DataEditorViewPath),
                new Dictionary<string, object>()
                {
                    { DataTableConfigurationEditor.FieldItems, listFields },
                    { MaxItemsConfigurationField.MaxItems, 0 },
                    { DisableSortingConfigurationField.DisableSorting, Constants.Values.False },
                    { DataTableConfigurationEditor.RestrictWidth, Constants.Values.True },
                    { DataTableConfigurationEditor.UsePrevalueEditors, Constants.Values.False }
                });

            Fields.Add(new CheckAllConfigurationField());

            Fields.Add(new OrientationConfigurationField());

            Fields.AddHideLabel();
        }

        internal class CheckAllConfigurationField : ConfigurationField
        {
            public const string CheckAll = "checkAll";

            public CheckAllConfigurationField()
                : base()
            {
                Key = CheckAll;
                Name = "Check all?";
                Description = "Include a toggle button to select or deselect all the options?";
                View = "boolean";
            }
        }
    }
}