// namespace Challenge5
// {
//   using UnityEngine;
//   using System.Collections.Generic;
//   using Shared.Utils;
//   using System;

//   public class FoodManager : MonoBehaviour
//   {
//     [SerializeField] private FoodController[] foodPrefabs;

//     private Dictionary<FoodType, ObjectPooling<FoodController>> foodPools;

//     private void Start()
//     {
//       foodPools = new();

//       foreach (var foodPrefab in foodPrefabs)
//       {
//         Func<FoodController> createFunc = () => Instantiate(foodPrefab, transform);
//         Func<FoodController, FoodController> deactiveFunc = (obj) =>
//         {
//           obj.gameObject.SetActive(false);
//           return obj;
//         };
//         Predicate<FoodController> isActivePredicate = obj => obj.gameObject.activeInHierarchy;

//         FoodType foodType = foodPrefab.GetComponent<FoodController>().Type;
//         foodPools[foodType] = new(createFunc, deactiveFunc, isActivePredicate);
//       }
//     }

//     public void SpawnFood(FoodType type, Vector3 position)
//     {
//       if (foodPools.TryGetValue(type, out var pool))
//       {
//         FoodController food = pool.GetFromPool();
//         food.transform.position = position;
//         food.gameObject.SetActive(true);
//       }
//       else
//       {
//         Debug.LogError($"No pool found for FoodType: {type}");
//       }
//     }
//   }
// }