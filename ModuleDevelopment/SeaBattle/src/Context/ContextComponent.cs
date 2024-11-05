namespace SeaBattle.Context;

public class ContextComponent : Attribute{
    public readonly Type SupplyProduct;

    public ContextComponent(Type supplyProduct){
        SupplyProduct = supplyProduct;
    }
}