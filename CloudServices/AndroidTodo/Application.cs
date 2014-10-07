using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using System.IO;
using AndroidTodo;
using Portable;
using Shared;

namespace AndroidTodo {
    [Application]
	public class AppDelegate : Application {

		public static AppDelegate Current { get; private set; }

		public TodoItemManager TaskMgr { get; set; }

		public AppDelegate(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer) {
                Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

			// AZURE
			TaskMgr = new TodoItemManager(AzureStorageImplementation.DefaultService);

			// PARSE
//			TaskMgr = new TodoItemManager(ParseStorageImplementation.Default);

			// DROPBOX
			// sets TaskManager during initialization
//			DropboxStore = new DropboxStorageImplementation ();
//			TaskMgr = new TodoItemManager (DropboxStore);

        }
		public DropboxStorageImplementation DropboxStore;
    }
}
