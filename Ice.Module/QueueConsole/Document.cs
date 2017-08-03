using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueConsole
{
    public class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
    public class DocumentManager
    {
        private Queue<Document> _queueDoc = new Queue<Document>();
        public void AddQueue(Document doc)
        {
            lock (this)
            {
                this._queueDoc.Enqueue(doc);
            }
        }
        public Document GetQueue()
        {
            Document doc = null;
            lock (this)
            {
                doc= this._queueDoc.Dequeue();
            }
            return doc;
        }
        public bool IsNull
        {
            get{ return _queueDoc.Count > 0; }
        }
    }
    public class ProcessDocument
    {
        DocumentManager _dm;
        public ProcessDocument(DocumentManager dm)
        {
            this._dm = dm;
        }
        public static void Start(DocumentManager dm)
        {
            new Thread(new ProcessDocument(dm).Run).Start();
        }
        public void Run()
        {
            while (true)
            {
                if (this._dm.IsNull)
                {
                    Document doc = this._dm.GetQueue();
                    Console.WriteLine($"线程目录:<<{doc.Title}>>");
                }
                Thread.Sleep(new Random().Next(2000));
            }
        }
    }
}
