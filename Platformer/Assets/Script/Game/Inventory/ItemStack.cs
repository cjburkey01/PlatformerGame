using UnityEngine;

public class ItemStack {

	private Item item;
	private int amount;

	public ItemStack(Item item) {
		this.item = item;
		amount = 1;
	}

	public ItemStack(Item item, int amount) {
		this.item = item;
		this.amount = amount;
	}

	public int getAmount() {
		return amount;
	}

	public Item getItem() {
		return item;
	}

	public bool Equals(Object other) {
		if(other is ItemStack) {
			ItemStack otherStack = (ItemStack) other;
			if(otherStack.item.Equals(item) && otherStack.amount == amount) {
				return true;
			}
		}
		return false;
	}

}