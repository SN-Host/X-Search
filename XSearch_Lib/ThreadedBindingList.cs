using System.ComponentModel;

namespace XSearch_Lib
{
    /// <summary>
    /// BindingList with threading support. 
    /// This seemed to be working a lot better than the currnet method (marshalling back to the main thread through event handlers), but the DataGridView threw an index error when adding new entries, so I had to leave it behind.
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
            ctx = SynchronizationContext.Current;
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
