using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace XSearch_Lib
{
    /// <summary>
    /// BindingList with threading support. 
    /// Previously, I raised events to marshal add operations back to the UI thread, but after discovering this implementation in later research I felt it was a cleaner alternative.
    /// Implementation from https://stackoverflow.com/questions/455766/how-do-you-correctly-update-a-databound-datagridview-from-a-background-thread
    /// </summary>
    public class ThreadedBindingList<T> : BindingList<T>
    {
        SynchronizationContext ctx = SynchronizationContext.Current;

        protected override void OnAddingNew(AddingNewEventArgs e)
        {

            if (ctx == null)
            {
                BaseAddingNew(e);
            }
            else
            {
                ctx.Send(delegate
                {
                    BaseAddingNew(e);
                }, null);
            }
        }

        void BaseAddingNew(AddingNewEventArgs e)
        {
            base.OnAddingNew(e);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (ctx == null)
            {
                BaseListChanged(e);
            }
            else
            {
                ctx.Send(delegate
                {
                    BaseListChanged(e);
                }, null);
            }
        }

        void BaseListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
        }
    }
}
