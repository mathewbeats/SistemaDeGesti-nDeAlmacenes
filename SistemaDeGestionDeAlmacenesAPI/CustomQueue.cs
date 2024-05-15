using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeAlmacenesAPI
{
    public class CustomQueue<T> where T : IEntityPrimaryProperties, IEntityAditionalProperties
    {

        public delegate void QueueEventHandler<T, U>(T sender, U eventArgs);

        //maneja los items de la aplicacion

        Queue<T> _queue = null;

        //evento publico al que queremos subscribirnos

        public event QueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;

        public CustomQueue()
        {

            _queue = new Queue<T>();

        }


        public int QueueLength
        {

            get { return _queue.Count; }


        }


        public void AddItem(T item)
        {
            _queue.Enqueue(item);

            QueueEventArgs queueEventArgs = new QueueEventArgs() { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateFormat)} Item Id: {item.Id} Item Name: {item.Name} Item Type: {item.Type} Item Quantity: {item.Quantity} has been added to the queue." };

            OnQueueChanged(queueEventArgs);
        }

        public T GetItem()
        {

            T item = _queue.Dequeue();
            QueueEventArgs queueEventArgs = new QueueEventArgs() { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateFormat)} Item Id: {item.Id} Item Name: {item.Name} Item Type: {item.Type} Item Quantity {item.Quantity} has been processed." };

            OnQueueChanged(queueEventArgs);

            return item;




        }

        protected virtual void OnQueueChanged(QueueEventArgs a)
        {
            //Centraliza el codigo para la cola personalizada

            CustomQueueEvent(this, a);

        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

    }


    public class QueueEventArgs : System.EventArgs
    {
        public string Message { get; set; }



    }
}
