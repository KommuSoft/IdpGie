//
//  DrawTheory.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Text;
using Gdk;
using IdpGie.Parser;
using Cairo;
using System.Diagnostics;

namespace IdpGie {
	public class DrawTheory : NameBase, ITimesensitive {
		private readonly List<ITheoryItem> elements = new List<ITheoryItem> ();
		private readonly Dictionary<IFunctionInstance,IShape> objects = new Dictionary<IFunctionInstance, IShape> ();
		private readonly Dictionary<EventType,LinkedList<IHook>> hooks = new Dictionary<EventType, LinkedList<IHook>> ();
		private readonly IAlterableReloadableChangeableStream<string> source;
		private double minTime = 0.0d;
		private double maxTime = 0.0d;
		private readonly SortedSet<double> chapters = new SortedSet<double> ();

		private event EventHandler changed;

		public IAlterableReloadableChangeableStream<string> Source {
			get {
				return this.source;
			}
		}

		public event EventHandler Changed {
			add {
				this.changed += value;
			}
			remove {
				this.changed -= value;
			}
		}

		public IShape this [IFunctionInstance key] {
			get {
				return this.objects [key];
			}
		}

		public List<ITheoryItem> Elements {
			get {
				return this.elements;
			}
		}

		public double MinTime {
			get {
				return this.minTime;
			}
		}

		public double MaxTime {
			get {
				return this.maxTime;
			}
		}

		public double TimeSpan {
			get {
				return this.maxTime - minTime;
			}
		}

		#region ITimesensitive implementation

		public double Time {
			get {
				IEnumerable<IShape> tail;
				IShape head = this.objects.Values.SplitHead (out tail);
				if (head != null) {
					double time = head.Time;
					foreach (IShape obj in tail) {
						if (obj.Time != time) {
							return double.NaN;
						}
					}
					return time;
				} else {
					return double.NaN;
				}
			}
			set {
				foreach (IShape obj in this.objects.Values) {
					obj.Time = value;
				}
			}
		}

		#endregion

		public DrawTheory (string name, IAlterableReloadableChangeableStream<string> source) : base (name) {
			this.source = source;
			this.source.Changed += HandleChanged;
			this.HandleChanged (null, null);
		}

		void HandleChanged (object sender, EventArgs e) {
			Lexer scnr = new Lexer (this.Source.Stream);
			IdpParser pars = new IdpParser (scnr, this);
			pars.Parse ();
		}

		protected void Clear () {
			this.elements.Clear ();
			this.objects.Clear ();
			this.hooks.Clear ();
			this.minTime = 0.0d;
			this.maxTime = 0.0d;
		}

		public void Reinitialize (IEnumerable<ITheoryItem> values) {
			if (values != null) {
				this.Clear ();
				if (values != null) {
					this.elements.AddRange (values);
				}
				this.Execute ();
			}
			this.Time = 0.0d;
		}

		public void RegisterTime (double time) {
			if (this.minTime > time) {
				this.minTime = time;
			} else if (this.maxTime < time) {
				this.maxTime = time;
			}
		}

		public void AddChapter (double time) {
			this.chapters.Add (time);
		}

		public void AddModifier (IFunctionInstance name, double time, Action<ShapeState> modifier) {
			this [name].State.AddModifier (time, modifier);
			this.RegisterTime (time);
			this.trigger_changed ();
		}

		private void trigger_changed () {
			EventArgs e = new EventArgs ();
			this.OnChanged (e);
			if (this.changed != null) {
				this.changed (this, e);
			}
		}

		protected virtual void OnChanged (EventArgs e) {

		}

		public string ToFullString () {
			StringBuilder sb = new StringBuilder ();
			foreach (ITheoryItem atm in elements) {
				sb.AppendFormat ("{0}.", atm);
				sb.AppendLine ();
			}
			return sb.ToString ();
		}

		internal void AddIdpdObject (IShape obj) {
			this.objects.Add (obj.Name, obj);
		}

		public IEnumerable<IShape> Objects () {
			return this.objects.Values;
		}

		public void Execute () {
			//TODO: Tp operator
			elements.Sort (PriorityComparator.Instance);
			foreach (ITheoryItem item in elements) {
				item.Execute (this);
			}
		}

		public void AddHook (IHook hook) {
			this.hooks.AddListDictionary (hook.HookType, hook);
		}

		public void FireHook (EventType type, params object[] parameters) {
			LinkedList<IHook> firelist;
			if (hooks.TryGetValue (type, out firelist)) {
				foreach (IHook hook in firelist) {
					hook.Execute (this, parameters);
				}
			}
		}

		public IEnumerable<EventType> GetHookTypes () {
			return this.hooks.Keys;
		}

		#region IComparable implementation

		public int CompareTo (ITimesensitive other) {
			if (other != null) {
				return this.Time.CompareTo (other.Time);
			} else {
				return -0x01;
			}
		}

		#endregion

	}
}

