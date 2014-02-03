using System;
using Cairo;

namespace IdpGie {
	[OutputDevice ("pdfstream", "Prints the content of a single timeframe as a pdf stream.")]
	public class OutputPdfDevice : OutputDevice {
		public OutputPdfDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			StripCanvasSize scs = manager.GenerateStripCanvasSize (0x01);
			using (PdfSurface surface = new PdfSurface (manager.OutputFile, scs.TotalWidth, scs.TotalHeight)) {
				using (Context ctx = new Context (surface)) {
					Point p = scs.GetCanvasOffset (0x00);
					ctx.Save ();
					ctx.Translate (p.X, p.Y);
					this.Theory.Time = manager.Time;
					CairoEngine engine = new CairoEngine (this.Theory);
					engine.Context = ctx;
					engine.Render ();
					ctx.Restore ();
				}
			}
		}

		#endregion

	}
}