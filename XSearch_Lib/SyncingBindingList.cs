using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace XSearch_Lib
{
    // TODO: Confirm deprecated then remove. 
    /*
    /// <summary>
    /// Binding list supporting cross-threaded operations.
    /// Implemented based on the following StackOverflow page: https://stackoverflow.com/questions/1351138/bindinglist-listchanged-event
    /// </summary>
    public class SyncingBindingList<T> : System.ComponentModel.BindingList<T>
    {
        public ISynchronizeInvoke _syncObject;
        private Action<System.ComponentModel.ListChangedEventArgs> _fireEventAction;

        public SyncingBindingList() : this(null)
        {
        }

        public SyncingBindingList(System.ComponentModel.ISynchronizeInvoke syncObject)
        {
            _syncObject = syncObject;
            _fireEventAction = FireEvent;
        }

        protected override void OnListChanged(System.ComponentModel.ListChangedEventArgs args)
        {
            if (_syncObject == null)
            {
                FireEvent(args);
            }
            else
            {
                _syncObject.Invoke(_fireEventAction, new object[] { args });
            }
        }

        private void FireEvent(System.ComponentModel.ListChangedEventArgs args)
        {
            base.OnListChanged(args);
        }
    }
    */
}
