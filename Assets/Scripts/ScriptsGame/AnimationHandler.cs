using Spine.Unity;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    PlayerMovement playerController; //Ref to our movement script

    [SpineAnimation]
    public string idle, jump, Run; //Animation ref.

    public SkeletonAnimation skeletonAnimation; //spine component ref.

    // Start is called before the first frame update
    void Start()
    {
        //Collect refrences
        playerController = transform.parent.GetComponent<PlayerMovement>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.velocityX < 0)
        {
            skeletonAnimation.Skeleton.ScaleX = -1;
        }
        else if (playerController.velocityX > 0)
        {
            skeletonAnimation.Skeleton.ScaleX = 1;
        }

        PlayAnimation(playerController.state.ToString().ToLower());
    }

    private void PlayAnimation(string animation)
    {
        if (skeletonAnimation.AnimationState.GetCurrent(0).ToString() != animation)
        {
            //Set animation
            skeletonAnimation.AnimationState.SetAnimation(0, animation, true);
        }
    }
}
