## Permissions

* `healgun.use` -- Allows player to use heal gun.

## Configuration

The plugins config is made simple and customizable

`Healgun` -- the weapon entity for healgun \
`Can Revive` -- if the healgun can revive players \
`Heal Amount` -- the amount of instant health given \
`Pending Health Amount` -- the amount of pending (passive) health \
`Revive Time` -- seconds it takes for player to be revived

**This is the weapons name and not the projectile E.G** `nailgun.entity`

```json
{
  "Healgun": "nailgun.entity",  
  "Can Revive": true,
  "Heal Amount": 5.0,
  "Pending Health Amount": 10.0,
  "Revive Time": 3.0
}
```

