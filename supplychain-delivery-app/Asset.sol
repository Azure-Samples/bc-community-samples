pragma solidity ^0.5.0;
contract Asset
{
  enum StateType { CanBeReserved, ReservationRequested, ReservationApproved }

  AssetDetails public asset;

  event AssetCreated();
  event ReservationRequested(address requestedBy, uint reservedDays, uint latitude, uint longitude);
  event ReservationGranted();
  event ReservationReleased();

  struct AssetDetails {
    string Description;
    uint Latitude;
    uint Longitude;
    address Owner;
    address RequestedBy;
    uint ReservedDays;
    uint ReservedOn;
    StateType State;
  }

  function estimateNow() private view returns (uint) { return (block.number * 15 seconds); }
  function expiresOn() private view returns (uint) { return (asset.ReservedOn + (asset.ReservedDays * 1 days)); }

  constructor (string memory description, address owner) public
	{
    asset = AssetDetails({
      Description: description,
      Latitude: 0,
      Longitude: 0,
      Owner: owner,
      RequestedBy: address(0x0),
      ReservedDays: 0,
      ReservedOn: 0,
      State: StateType.CanBeReserved
    });
    emit AssetCreated();
  }

  function RequestReservation(address requestedBy, uint reservedDays, uint longitude, uint latitude) public
	{
    require(asset.State == StateType.CanBeReserved, "The asset is already reserved");
    asset.State = StateType.ReservationRequested;
    asset.RequestedBy = requestedBy;
    asset.ReservedDays = reservedDays;
    asset.Longitude = longitude;
    asset.Latitude = latitude;
    emit ReservationRequested(requestedBy, reservedDays, longitude, latitude);
  }

  function ApproveReservation() public
	{
    require(
      asset.Owner == msg.sender,
      "Only the owner can approve the reservation request"
    );
    require(asset.State == StateType.ReservationRequested, "The asset is already reserved");

    asset.State = StateType.ReservationApproved;
    asset.ReservedOn = estimateNow();
    emit ReservationGranted();
  }

  function ReleaseReservation() public
	{
    require(asset.State == StateType.ReservationApproved, "Not reserved");
    bool isExpired = estimateNow() > expiresOn();
    require(asset.RequestedBy == msg.sender || isExpired, "If the reservation is not expired, only the reservation requestor can release it");

    asset.State = StateType.CanBeReserved;
    asset.RequestedBy = address(0x0);
    asset.ReservedOn = 0;
    asset.ReservedDays = 0;
    asset.Longitude = 0;
    asset.Latitude = 0;
    emit ReservationReleased();
  }
}