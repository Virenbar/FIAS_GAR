using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FIAS.Core.Models;

namespace FIASUpdate.Controls
{
    internal class AddressLVI : ListViewItem
    {
        private static readonly Font Consolas = new Font("Consolas", 8.25f);
        private static readonly Font Segoe = new Font("Segoe UI", 8.25f);

        public AddressLVI(FIASRegistryAddress address) : this(address, true) { }

        public AddressLVI(FIASRegistryAddress address, bool full)
        {
            Address = address;
            Text = $"{Address.ObjectGUID}";
            if (full)
            {
                SubItems.AddRange(new[] { Address.NameFull, Address.AddressFull });
            }
            else
            {
                SubItems.Add(Address.AddressFull);
            }
            UseItemStyleForSubItems = false;
            Font = Consolas;
        }

        public FIASRegistryAddress Address { get; }

        public static AddressLVI[] FromList(IEnumerable<FIASRegistryAddress> addresses)
        {
            return addresses
                .Select(R => new AddressLVI(R))
                .ToArray();
        }

        public static implicit operator FIASRegistryAddress(AddressLVI lvi) => lvi.Address;
    }
}