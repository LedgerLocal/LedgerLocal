using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class AssetOptionHelper
    {

        //     /*

        //           enum asset_issuer_permission_flags
        //{
        //   charge_market_fee    = 0x01, /**< an issuer-specified percentage of all market trades in this asset is paid to the issuer */
        //     white_list           = 0x02, /**< accounts must be whitelisted in order to hold this asset */
        //   override_authority   = 0x04, /**< issuer may transfer asset back to himself */
        //   transfer_restricted  = 0x08, /**< require the issuer to be one party to every transfer */
        //   disable_force_settle = 0x10, /**< disable force settling */
        //   global_settle        = 0x20, /**< allow the bitasset issuer to force a global settling -- this may be set in permissions, but not flags */
        //   disable_confidential = 0x40, /**< allow the asset to be used with confidential transactions */
        //   witness_fed_asset    = 0x80, /**< allow the asset to be fed by witnesses */
        //   committee_fed_asset  = 0x100 /**< allow the asset to be fed by the committee */
        //};
        // const static uint32_t ASSET_ISSUER_PERMISSION_MASK = charge_market_fee | white_list | override_authority | transfer_restricted | disable_force_settle | global_settle | disable_confidential
        //    | witness_fed_asset | committee_fed_asset;
        // const static uint32_t UIA_ASSET_ISSUER_PERMISSION_MASK = charge_market_fee | white_list | override_authority | transfer_restricted | disable_confidential;


        //      */


        public ulong GRAPHENE_100_PERCENT = 10000;
        public ulong GRAPHENE_1_PERCENT = 10000 / 100;

        public uint GetAssetBool(GrapheneIssuerPermissions perms)
        {
            //"charge_market_fee",
            //"white_list",
            //"override_authority",
            //"transfer_restricted",
            //"disable_confidential"

            uint res = 0;

            if (perms.ChargeMarketFee)
            {
                res = res + 0x01;
            }

            if (perms.WhiteList)
            {
                res = res + 0x02;
            }

            if (perms.OverrideAuthority)
            {
                res = res + 0x04;
            }

            if (perms.TransferRestricted)
            {
                res = res + 0x08;
            }

            if (perms.DisableForceSettle)
            {
                res = res + 0x10;
            }

            if (perms.GlobalSettle)
            {
                res = res + 0x20;
            }

            if (perms.DisableConfidential)
            {
                res = res + 0x40;
            }

            if (perms.WitnessFedAsset)
            {
                res = res + 0x80;
            }

            if (perms.WitnessFedAsset)
            {
                res = res + 0x100;
            }

            return res;
        }

        public uint GetFlag()
        { 
            return GetAssetBool(new GrapheneIssuerPermissions()
            {
                ChargeMarketFee = true,
                CommitteeFedAsset = true,
                DisableConfidential = true,
                DisableForceSettle = true,
                GlobalSettle = false,
                OverrideAuthority = true,
                TransferRestricted = true,
                WhiteList = true,
                WitnessFedAsset = false
            });
        }

        public uint GetPermissions(bool isBitAsset = false)
        {
            if (isBitAsset)
            {
                return GetAssetBool(new GrapheneIssuerPermissions()
                {
                    ChargeMarketFee = true,
                    CommitteeFedAsset = true,
                    DisableConfidential = true,
                    DisableForceSettle = true,
                    GlobalSettle = true,
                    OverrideAuthority = true,
                    TransferRestricted = true,
                    WhiteList = true,
                    WitnessFedAsset = true
                });
            }
            else
            {
                return GetAssetBool(new GrapheneIssuerPermissions()
                {
                    //"charge_market_fee",
                    //"white_list",
                    //"override_authority",
                    //"transfer_restricted",
                    //"disable_confidential"

                    ChargeMarketFee = true,
                    CommitteeFedAsset = false,
                    DisableConfidential = true,
                    DisableForceSettle = false,
                    GlobalSettle = false,
                    OverrideAuthority = true,
                    TransferRestricted = true,
                    WhiteList = true,
                    WitnessFedAsset = false
                });
            }
        }

    }
}
