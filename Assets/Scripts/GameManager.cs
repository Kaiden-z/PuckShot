using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   
   private IGameMode gameMode;
   
   private void Awake()
   {
       if (Instance != null && Instance != this)
       {
           Destroy(gameObject);
       }
       else
       {
           Instance = this;
           DontDestroyOnLoad(gameObject);
       }
   }

   private void Initialize()
   {
       
   }
}
