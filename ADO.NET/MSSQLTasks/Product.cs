namespace MSSQLTasks
{
    class Product
    {
        public string productName;
        public int supplierID;
        public int categoryID;
        public string quantityPerUnit;
        public decimal unitPrice;
        public int unitsInStock;
        public int unitsOnOrder;
        public int reorderLevel;
        public bool Discontinued;

        public Product(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, bool Discontinued)
        {
            this.productName = productName;
            this.supplierID = supplierID;
            this.categoryID = categoryID;
            this.quantityPerUnit = quantityPerUnit;
            this.unitPrice = unitPrice;
            this.unitsInStock = unitsInStock;
            this.unitsOnOrder = unitsOnOrder;
            this.reorderLevel = reorderLevel;
            this.Discontinued = Discontinued;
        }
    }
}
