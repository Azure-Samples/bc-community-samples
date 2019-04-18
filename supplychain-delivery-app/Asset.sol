pragma solidity ^0.5.0;
contract Asset
{
  enum StateType { CanBeReserved, Reserved }
  AssetDetails public asset;
  struct AssetDetails {
    StateType State;
    string Description;
    address Owner;
    address ReservedBy;
    uint ReservedOn;
    uint ReservedDays;
    uint Longitude;
    uint Latitude;
  }
  event AssetCreated();
  event ReservationGranted(uint reservedDays, uint latitude, uint longitude);
  event ReservationReleased();
  constructor (string memory description) public
	{
    asset = AssetDetails({
      Description: description,
      Owner: address(msg.sender),
      ReservedBy: address(0x0),
      ReservedOn: 0,
      ReservedDays: 0,
      Longitude: 0,
      Latitude: 0,
      State: StateType.CanBeReserved
    });
    emit AssetCreated();
  }
  function estimateNow() private view returns (uint) { return (block.number * 15 seconds); }
  function expiresOn() private view returns (uint) { return (asset.ReservedOn + (asset.ReservedDays * 1 days)); }
  function Reserve(address reservedBy, uint reservedDays, uint longitude, uint latitude) public
	{
    require(asset.Owner == msg.sender, "Only the current owner can assign a new reservation" );
    require(asset.State == StateType.CanBeReserved, "The asset is already reserved");

    asset.State = StateType.Reserved;
    asset.ReservedBy = reservedBy;
    asset.ReservedOn = estimateNow();
    asset.ReservedDays = reservedDays;
    asset.Longitude = longitude;
    asset.Latitude = latitude;
    emit ReservationGranted(reservedDays, longitude, latitude);
  }

  function ReleaseReservation() public
	{
    require(asset.State == StateType.Reserved, "Not currently reserved");
    bool isExpired = estimateNow() > expiresOn();
    require(asset.ReservedBy == msg.sender || isExpired, "If the reservation is not expired, only the reservation owner can release it");

    asset.State = StateType.CanBeReserved;
    asset.ReservedBy = address(0x0);
    asset.ReservedOn = 0;
    asset.ReservedDays = 0;
    asset.Longitude = 0;
    asset.Latitude = 0;
    emit ReservationReleased();
  }
}