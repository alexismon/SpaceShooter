/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMMOBOX = 433237507U;
        static const AkUniqueID PLAY_ASTEROID_DAMAGE = 1717614887U;
        static const AkUniqueID PLAY_ASTEROID_EXPLOSION = 4237284121U;
        static const AkUniqueID PLAY_ENEMYSHIP_DAMAGE = 3733942808U;
        static const AkUniqueID PLAY_ENEMYSHIP_EXPLOSION = 1405656152U;
        static const AkUniqueID PLAY_GAMESTART = 1497459184U;
        static const AkUniqueID PLAY_LASER = 2270376495U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_NUKE = 158275041U;
        static const AkUniqueID PLAY_SPACESHIP_DAMAGE = 2147041706U;
        static const AkUniqueID PLAY_SPACESHIP_EXPLOSION = 2187574386U;
        static const AkUniqueID PLAY_SPACESTATION_DAMAGE = 856647580U;
        static const AkUniqueID PLAY_SPACESTATION_EXPLOSION = 2396634876U;
        static const AkUniqueID PLAY_SPECIALNUKE = 1645846432U;
        static const AkUniqueID PLAY_UI_ENTER = 2982660583U;
        static const AkUniqueID PLAY_UI_HIGHLIGHT = 2671607925U;
        static const AkUniqueID STOP_MUSIC = 2837384057U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAME_STATE
        {
            static const AkUniqueID GROUP = 766723505U;

            namespace STATE
            {
                static const AkUniqueID DEATH = 779278001U;
                static const AkUniqueID GAME = 702482391U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PAUSE = 3092587493U;
            } // namespace STATE
        } // namespace GAME_STATE

        namespace HEALTH
        {
            static const AkUniqueID GROUP = 3677180323U;

            namespace STATE
            {
                static const AkUniqueID DAMAGED = 3258988170U;
                static const AkUniqueID DEATH = 779278001U;
                static const AkUniqueID FULL = 2510516222U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID VERYDAMAGED = 384135286U;
            } // namespace STATE
        } // namespace HEALTH

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID UI = 1551306167U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
