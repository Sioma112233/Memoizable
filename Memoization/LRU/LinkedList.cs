using System;
using System.Collections;
using System.Collections.Generic;

namespace Memoization
{
	internal class MyLinkedList<T> : IEnumerable<Node<T>>
	{
		private int _count;
		private Node<T> _head;
		private Node<T> _tail;
		
		public MyLinkedList()
		{
			_head = null;
			_tail = null;
		}

		public int Size => _count;
		public Node<T> Head => _head;
		public Node<T> Tail => _tail;

		public void AddFirst(Node<T> node)
		{
			node.next = _head;
			
			// first insertion
			if (_head == null) {
				_tail = node;
			}
			
			_head = node;
			_count++;
		}

		public Node<T> AddFirst(T item)
		{
			var node = new Node<T>(item);
			AddFirst(node);
			return node;
		}

		public Node<T> AddLast(T item)
		{
			var node = new Node<T>(item);

			// first insertion
			if (_head == null) {
				_head = node;
			}
			else
				_tail.next = node;
				
			_tail = node;

			_count++;

			return node;
		}

		public void Remove(Node<T> item)
		{
			bool found = false;
			if (_head == item) {
				_head = _head.next;
				item.next = null;

				if (_tail == item) {
					_tail = null;
				}

				found = true;
			}
			else {
				Node<T> iter = _head;
				while (iter != null && !found) {
					if (iter.next == item) {
						iter.next = item.next;

						if (_tail == item)
							_tail = iter;

						item.next = null; // should help GC to collect item
						found = true;
					}

					iter = iter.next;
				}
			}

			if (!found) 
				throw new Exception("node not found in list");
			
			_count--;
		}

		public void Clear()
		{
			while (_head != null) {
				var next = _head.next;
				_head.next = null;

				_head = next;
			}

			_count = 0;
			_tail = null;
		}
		
		public IEnumerator<Node<T>> GetEnumerator()
		{
			Node<T> iter = _head;
			while (iter != null) {
				yield return iter;

				iter = iter.next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}