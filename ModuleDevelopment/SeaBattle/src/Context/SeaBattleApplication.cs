using System.Reflection;
using SeaBattle.Presenter.Views;

namespace SeaBattle.Context;

public class SeaBattleApplication{
    public readonly Object Configuration;
    
    public SeaBattleApplication(Type configurationClass){
        object[] atrributeObjects = configurationClass.GetCustomAttributes(false);

        foreach (Object attribute in atrributeObjects){
            if (attribute is ViewConfigurationContext){
                Configuration = Activator.CreateInstance(configurationClass);
            }
        }
    }

    public IEnumerable<T> Supply<T>(){
        List<T> products = new List<T>();

        MethodInfo[] configSuppliers = Configuration
            .GetType()
            .GetMethods();

        List<MethodInfo> suppliersOfRequired = configSuppliers
            .Where(x => 
                x.GetCustomAttributes(false).Where(x => x is ContextComponent).Count() > 0)
            .Where(x => x.ReturnType == typeof(T))
            .ToList();

        suppliersOfRequired.ForEach(x => 
            products.Add((T)x.Invoke(Configuration, null))
        );

        // for (int i = 0; i < configSuppliers.Length; i++){
        //     Object[] attributeObjects = configSuppliers[i].GetCustomAttributes(false);

        //     for (int j = 0; j < attributeObjects.Length; j++){
        //         if (attributeObjects[j] is ContextComponent){
        //             if (configSuppliers[i].ReturnType == ){
        //                 products.Add((T)configSuppliers[i].Invoke(Configuration, null));
        //             }
        //         }
        //     }
        // }
        
        return products; 
    }
}