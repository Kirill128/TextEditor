using ParserWithList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using TextEditorView.View;

namespace TextEditorView.Model
{
    public class FlowDocumentBox
    {
        public FlowDocument Document { set; get; }
        public string DocumentPathInFileSystem { get; set; }
        public ButtonForFlowDoc ButtonToManipulateDoc { get; set; }

        public Page Page { get; set; }
        public FlowDocumentBox(FlowDocument doc,string pathInFileSystem) {
            this.Document = doc;
            this.DocumentPathInFileSystem = pathInFileSystem;
        }
        public FlowDocumentBox(FlowDocument doc, string pathInFileSystem, ButtonForFlowDoc buttonToManipulate) :this(doc, pathInFileSystem) {
            this.ButtonToManipulateDoc = buttonToManipulate;
        }
    }
}
