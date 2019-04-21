pragma solidity ^0.5.0;
contract Asset
{
  enum StateType { WaitingToBeReceived, Received }

  AssetDetails public asset;

  event AssetSent(address sentTo, string description);
  event AssetReceived(address receivedBy, uint latitude, uint longitude);

  struct AssetDetails {
    string Description;
    uint Latitude;
    uint Longitude;
    address Owner;
    address SentTo;
    address ReceivedBy;
    uint ReceivedOn;
    string ReceivedImageMetaData;
    StateType State;
  }

  function estimateNow() private view returns (uint) { return (block.number * 15 seconds); }

  constructor (string memory description, address sentTo) public
	{
    asset = AssetDetails({
      Description: description,
      Latitude: 0,
      Longitude: 0,
      Owner: msg.sender,
      SentTo: msg.sender,
      ReceivedBy: address(0x0),
      ReceivedOn: 0,
      ReceivedImageMetaData: "",
      State: StateType.WaitingToBeReceived
    });
    emit AssetSent(sentTo, description);
  }

  function ReceiveAsset(uint longitude, uint latitude, string memory imageMetaData) public
	{
    require(asset.State == StateType.WaitingToBeReceived, "The asset is already received");
    require(asset.SentTo == msg.sender, "The asset must be received by the expected party");

    asset.State = StateType.Received;
    asset.ReceivedBy = msg.sender;
    asset.ReceivedImageMetaData = imageMetaData;
    asset.Longitude = longitude;
    asset.Latitude = latitude;
    emit AssetReceived(msg.sender, longitude, latitude);
  }
}