using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Plugins
{
    public interface IPluginsConvention
    {
        string PluginName { get; }
        UserControl GetControl { get; }

        PluginsConventionElement GetElement { get; }

        Form GetForm(PluginsConventionElement element);

        bool DeleteElement(PluginsConventionElement element);

        void ReloadData();

        bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument);

        bool CreateTableDocument(PluginsConventionSaveDocument saveDocument);

        bool CreateChartDocument(PluginsConventionSaveDocument saveDocument);
    }
}
