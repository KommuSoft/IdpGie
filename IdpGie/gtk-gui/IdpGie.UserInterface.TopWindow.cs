
// This file has been generated by the GUI designer. Do not modify.
namespace IdpGie.UserInterface
{
	public partial class TopWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action ControlsAction;
		private global::Gtk.Action PlayAction;
		private global::Gtk.Action PauseAction;
		private global::Gtk.Action RewindAction;
		private global::Gtk.Action ForwardAction;
		private global::Gtk.Action PreviousChapterAction;
		private global::Gtk.Action NextChapterAction;
		private global::Gtk.Action FileAction;
		private global::Gtk.Action OpenAction;
		private global::Gtk.Action ExitAction;
		private global::Gtk.VBox vhierarchy;
		private global::Gtk.MenuBar menubar1;
		private global::Gtk.VBox mainhierarchy;
		private global::IdpGie.BlueprintMediabar mediabar;
		private global::IdpGie.BlueprintTabControl tabcontrol;
		private global::Gtk.Statusbar statusbar;
		private global::Gtk.Label statusLabel;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget IdpGie.UserInterface.TopWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.ControlsAction = new global::Gtk.Action ("ControlsAction", global::Mono.Unix.Catalog.GetString ("Controls"), null, null);
			this.ControlsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Controls");
			w1.Add (this.ControlsAction, null);
			this.PlayAction = new global::Gtk.Action ("PlayAction", global::Mono.Unix.Catalog.GetString ("Play"), null, "play");
			this.PlayAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Play");
			w1.Add (this.PlayAction, null);
			this.PauseAction = new global::Gtk.Action ("PauseAction", global::Mono.Unix.Catalog.GetString ("Pause"), null, "pause");
			this.PauseAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Pause");
			w1.Add (this.PauseAction, null);
			this.RewindAction = new global::Gtk.Action ("RewindAction", global::Mono.Unix.Catalog.GetString ("Rewind"), null, "rewind");
			this.RewindAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Rewind");
			w1.Add (this.RewindAction, null);
			this.ForwardAction = new global::Gtk.Action ("ForwardAction", global::Mono.Unix.Catalog.GetString ("Forward"), null, "forward");
			this.ForwardAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Forward");
			w1.Add (this.ForwardAction, null);
			this.PreviousChapterAction = new global::Gtk.Action ("PreviousChapterAction", global::Mono.Unix.Catalog.GetString ("Previous Chapter"), null, "previous");
			this.PreviousChapterAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Previous Chapter");
			w1.Add (this.PreviousChapterAction, null);
			this.NextChapterAction = new global::Gtk.Action ("NextChapterAction", global::Mono.Unix.Catalog.GetString ("Next Chapter"), null, "next");
			this.NextChapterAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Next Chapter");
			w1.Add (this.NextChapterAction, null);
			this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
			this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
			w1.Add (this.FileAction, null);
			this.OpenAction = new global::Gtk.Action ("OpenAction", global::Mono.Unix.Catalog.GetString ("Open"), null, null);
			this.OpenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Open");
			w1.Add (this.OpenAction, null);
			this.ExitAction = new global::Gtk.Action ("ExitAction", global::Mono.Unix.Catalog.GetString ("Exit"), null, "Quit");
			this.ExitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exit");
			w1.Add (this.ExitAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "IdpGie.UserInterface.TopWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Idp-GIE The IDP Graphical Interactive Environment");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.AllowShrink = true;
			this.DefaultWidth = 1024;
			this.DefaultHeight = 800;
			// Container child IdpGie.UserInterface.TopWindow.Gtk.Container+ContainerChild
			this.vhierarchy = new global::Gtk.VBox ();
			this.vhierarchy.Name = "vhierarchy";
			// Container child vhierarchy.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='OpenAction' action='OpenAction'/><separator/><menuitem name='ExitAction' action='ExitAction'/></menu><menu name='ControlsAction' action='ControlsAction'><menuitem name='PlayAction' action='PlayAction'/><menuitem name='PauseAction' action='PauseAction'/><menuitem name='RewindAction' action='RewindAction'/><menuitem name='ForwardAction' action='ForwardAction'/><menuitem name='PreviousChapterAction' action='PreviousChapterAction'/><menuitem name='NextChapterAction' action='NextChapterAction'/></menu></menubar></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.vhierarchy.Add (this.menubar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vhierarchy [this.menubar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vhierarchy.Gtk.Box+BoxChild
			this.mainhierarchy = new global::Gtk.VBox ();
			this.mainhierarchy.Name = "mainhierarchy";
			// Container child mainhierarchy.Gtk.Box+BoxChild
			this.mediabar = new global::IdpGie.BlueprintMediabar ();
			this.mediabar.Name = "mediabar";
			this.mediabar.Min = 0;
			this.mediabar.Max = 0;
			this.mediabar.Current = 0;
			this.mediabar.Speed = 1;
			this.mainhierarchy.Add (this.mediabar);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.mainhierarchy [this.mediabar]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child mainhierarchy.Gtk.Box+BoxChild
			this.tabcontrol = new global::IdpGie.BlueprintTabControl ();
			this.tabcontrol.Name = "tabcontrol";
			this.tabcontrol.Min = 0;
			this.tabcontrol.Max = -1;
			this.tabcontrol.Current = 0;
			this.mainhierarchy.Add (this.tabcontrol);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.mainhierarchy [this.tabcontrol]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.vhierarchy.Add (this.mainhierarchy);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vhierarchy [this.mainhierarchy]));
			w5.Position = 1;
			// Container child vhierarchy.Gtk.Box+BoxChild
			this.statusbar = new global::Gtk.Statusbar ();
			this.statusbar.Name = "statusbar";
			this.statusbar.Spacing = 6;
			// Container child statusbar.Gtk.Box+BoxChild
			this.statusLabel = new global::Gtk.Label ();
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Loading...");
			this.statusbar.Add (this.statusLabel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.statusbar [this.statusLabel]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			this.vhierarchy.Add (this.statusbar);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vhierarchy [this.statusbar]));
			w7.Position = 3;
			w7.Expand = false;
			w7.Fill = false;
			this.Add (this.vhierarchy);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
			this.ExitAction.Activated += new global::System.EventHandler (this.Quit);
		}
	}
}
